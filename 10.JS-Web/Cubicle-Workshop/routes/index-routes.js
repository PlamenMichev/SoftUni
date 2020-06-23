const cubeController = require('../controllers/cube-controller');

module.exports = (app) => {
    app.get('/', async (req, res) => {
        const cubes = await cubeController.getAllCubes();
        res.render('index', {
            cubes
        });
    });


    app.get('/about', (req, res) => {
        res.render('about');
    });

};