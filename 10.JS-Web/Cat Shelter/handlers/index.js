const homeHandler = require('./home');
const staticFilesHandler = require('./static-files');
const catsHandler = require('./cats');
const searchHandler = require('./search.js');

module.exports = [homeHandler, staticFilesHandler, catsHandler, searchHandler];