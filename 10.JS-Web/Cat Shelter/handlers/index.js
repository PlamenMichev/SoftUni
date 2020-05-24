const homeHandler = require('./home');
const staticFilesHandler = require('./static-files');
const catsHandler = require('./cats');

module.exports = [homeHandler, staticFilesHandler, catsHandler];