const cubeController = require('../controllers/cube-controller');
const { isLoggedIn } = require('../controllers/user-controller');

module.exports = (app) => {
    app.get('/', isLoggedIn, async (req, res) => {
        const cubes = await cubeController.getAllCubes();
        res.render('index', {
            cubes,
            isLoggedIn: req.isLoggedIn,
        });
    });


    app.get('/about', isLoggedIn , (req, res) => {
        res.render('about', {
            isLoggedIn: req.isLoggedIn,
        });
    });

};