const env = process.env.NODE_ENV || 'development';

const mongoose = require('mongoose');
const config = require('./config/config')[env];
const app = require('express')();

const dbUrl = `mongodb+srv://admin:${process.env.DB_PASSWORD}@cubicle-0kjaa.mongodb.net/Cubicle?retryWrites=true&w=majority`;
mongoose.connect(dbUrl, { useNewUrlParser: true, useUnifiedTopology: true } ,(err) => {
    if (err) {
        throw err;
    }

    console.log('Db is connected!');
});

require('./config/express')(app);
require('./routes/index-routes')(app);
require('./routes/cube-routes')(app);
require('./routes/accessory-routes')(app);


app.get('*', (req, res) => {
    res.render('404');
});

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));