const cubeController = require('../controllers/cube-controller');

module.exports = (app) => {
    app.get('/create', (req, res) => {
        res.render('create');
    });

    app.post('/create', async (req, res) => {
        const newCube = await cubeController.addCube(req.body.name, req.body.description, req.body.difficultyLevel, req.body.imageUrl);
        res.redirect('/');
    });
    app.get('/details/:id', async (req, res) => {
        const cube = await cubeController.getCubeById(req.params.id);
        res.render('details', {
            ...cube,
        });
    });
};