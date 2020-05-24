const url = require('url');
const fs = require('fs');
const path = require('path');

function getContentType(url) {
    if (url.endsWith('css')) {
        return 'text/css';
    } else if (url.endsWith('ico')) {
        return 'image/x-icon';
    } else if (url.endsWith('png')) {
        return 'image/png';
    } else if (url.endsWith('html')) {
        return 'text/html';
    } else if (url.endsWith('js')) {
        return 'text/jscript';
    }
}

module.exports = async (req, res) => {
    const pathname = url.parse(req.url).pathname;
    
    if (pathname.startsWith('/content') && req.method === 'GET') {
        await fs.readFile(path.join(__dirname, `../${pathname}`), 'utf-8', (err, data) => {
            if (err) {
                console.error(err);

                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('File not found!');
                res.end();

                return;
            }

            let contentType = getContentType(pathname);
            res.writeHead(200, {
                'Content-Type': contentType
            });

            res.write(data);
            res.end();
        });
    } else {
        return true;
    }
}