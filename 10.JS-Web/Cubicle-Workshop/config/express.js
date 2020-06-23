const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const path = require('path');

module.exports = (app) => {
    
    //Setup the view engine
    app.engine('.hbs', handlebars({
        extname: '.hbs'
    }));
    app.set('view engine', '.hbs');
    app.use(express.urlencoded({ extended: true }));
    app.use(cookieParser());

    // Setup static files
    app.use('/static', express.static('static'));
};