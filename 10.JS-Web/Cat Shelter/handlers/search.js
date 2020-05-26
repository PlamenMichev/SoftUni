const url = require('url');
const fs = require('fs');
const path = require('path');
const cats = require('../data/cats.json');

module.exports = async (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/search' && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, '../views/home/index.html')
        );
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

                const url = req.url;
                let searchQuery = url.slice(url.indexOf('query=') + 6);
                let foundCats = [];

                for (let cat of cats) {
                    for (const key of Object.keys(cat)) {
                        console.log(key);
                        if ((key != 'id' && key != 'image') && cat[key].includes(searchQuery)) {
                            foundCats.push(cat);
                            break;
                        }
                    }
                }

                let modifiedCats = foundCats.map((cat) => 
                `<li>
                <img src="${path.join('./content/images/' + cat.image)}" alt="${cat.name}">
                <h3></h3>
                <p><span>Breed: </span>${cat.breed}</p>
                <p><span>Description: </span>${cat.description}</p>
                <ul class="buttons">
                    <li class="btn edit"><a href="/cats-edit/${cat.id}">Change Info</a></li>
                    <li class="btn delete"><a href="/cats-find-new-home/${cat.id}">New Home</a></li>
                </ul>
            </li>`
            );

            let modifiedData = data.toString().replace('{{cats}}', modifiedCats);
            res.write(modifiedData);
            res.end(); 
            });
    } else {
        return true;
    }
}
