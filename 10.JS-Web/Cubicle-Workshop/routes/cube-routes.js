const cubeController = require('../controllers/cube-controller');
const { isAuthenticated, isLoggedIn } = require('../controllers/user-controller');

module.exports = (app) => {
    app.get('/create', isAuthenticated, isLoggedIn, (req, res) => {
        res.render('create', {
            isLoggedIn: req.isLoggedIn,
        });
    });

    app.post('/create', isAuthenticated, isLoggedIn, async (req, res) => {
        const newCube = await cubeController.addCube(req.body.name, req.body.description, req.body.difficultyLevel, req.body.imageUrl);
        res.redirect('/');
    });

    app.get('/details/:id', isLoggedIn, async (req, res) => {
        const cube = await cubeController.getCubeById(req.params.id);
        res.render('details', {
            ...cube,
            isLoggedIn: req.isLoggedIn,
        });
    });
};