const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');
const breeds = require('../data/breeds.json');
const cats = require('../data/cats.json');

module.exports = async (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        let filePath = path.join(`${__dirname}`, '../views/addCat.html');
        await fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('Something went wrong!');
                res.end();
                return;
            }

            let catBreedPlaceholder = breeds.map((breed) => `<option value="${breed}">${breed}</option>`);
            let modifiedData = data.toString().replace('{{catBreeds}}', catBreedPlaceholder);

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            res.write(modifiedData);
            res.end();
        });
    } else if (pathname === '/cats/add-cat' && req.method === 'POST') {
        let form = new formidable.IncomingForm();
        form.uploadDir = `D:\\Softuni-Courses(Repo)\\SoftUni\\10.JS-Web\\Cat Shelter\\content\\images`

        form.on('fileBegin', function(name, file) {
            file.path = form.uploadDir + "/" + file.name;
        });

        form.parse(req, async (err, fields, files) => {
            if (err) {
                return err;
            }

            let picture = files;

            let newCat = {
                id: cats[cats.length - 1] == undefined ? 1 : cats[cats.length - 1].id + 1,
                name: fields['name'],
                description: fields['description'],
                breed: fields['breed'],
                image: picture.upload.name
            };

            cats.push(newCat);
            await fs.writeFile(path.join(__dirname, '../data/cats.json'), JSON.stringify(cats), 'utf8', function(err) {});

            await fs.readFile(path.join(__dirname, '../views/home/index.html'), (err, data) => {
                res.writeHead(301, {
                    'Location': '/'
                });

                res.write(data);
                res.end();
            });
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        let filePath = path.join(`${__dirname}`, '../views/addBreed.html');
        console.log(filePath);
        await fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('Something went wrong!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            res.write(data);
            res.end();
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'POST') {
        let body = '';

        req.on('data', function (data) {
            body += data;

            // Too much POST data, kill the connection!
            // 1e6 === 1 * Math.pow(10, 6) === 1 * 1000000 ~~~ 1MB
            if (body.length > 1e6)
            req.connection.destroy();
        });

        req.on('end', async function () {
            let post = qs.parse(body);
            let breed = post['breed'];
            if (breed.length > 3 && !breeds.includes(breed)) {
                breeds.push(breed);
            }
            await fs.writeFile(path.join(__dirname, '../data/breeds.json'), JSON.stringify(breeds), 'utf8', function (err) {
                }
            );

            await fs.readFile(path.join(__dirname, '../views/home/index.html'), (err, data) => {
                res.writeHead(301, {
                    'Location': '/'
                });

                res.write(data);
                res.end();
            });
        });
    } else if (pathname.includes('/cats-edit') && req.method === 'GET') {
            await fs.readFile(path.join(__dirname, '../views/editCat.html'), (err, data) => {
                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });

                let catId = pathname.slice(pathname.lastIndexOf('/') + 1);
                let cat = cats.filter((cat) => {
                    return cat.id == catId
                });

                cat = cat[0];

                let modifiedData = data.toString().replace('{{id}}', catId);
                modifiedData = modifiedData.replace('{{name}}', cat.name);
                modifiedData = modifiedData.replace('{{description}}', cat.description);

                modifiedData = modifiedData.replace(new RegExp('{{breed}}', 'g'), cat.breed);

                let modifiedBreeds = breeds
                .filter((b) => b != cat.breed)
                .map((breed) => 
                    `<option value="${breed}">${breed}</option>`
                );
                modifiedData = modifiedData.replace('{{breeds}}', modifiedBreeds);

                res.write(modifiedData);
                res.end();
            });
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'GET') {
        await fs.readFile(path.join(__dirname, '../views/catShelter.html'), (err, data) => {
            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            let catId = pathname.slice(pathname.lastIndexOf('/') + 1);
            let cat = cats.filter((cat) => {
                return cat.id == catId
            });

            cat = cat[0];

            let modifiedData = data.toString().replace('{{id}}', catId);
            modifiedData = modifiedData.replace(new RegExp('{{name}}', 'g'), cat.name);
            modifiedData = modifiedData.replace('{{description}}', cat.description);
            modifiedData = modifiedData.replace('{{image}}', `${path.join('../content/images/' + cat.image)}`);

            modifiedData = modifiedData.replace(new RegExp('{{breed}}', 'g'), cat.breed);
            res.write(modifiedData);
            res.end();
        });
    } else {
        return true;
    }
}