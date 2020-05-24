const url = require('url');
const fs = require('fs');
const path = require('path');
// const cats = require('../data/cats.json');

module.exports = async (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if ((pathname === '/' || pathname === '/home') && req.method === 'GET') {
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
            
                res.write(data);
                res.end();
            });
    } else {
        return true;
    }
}
