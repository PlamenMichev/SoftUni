const cubeController = require('../controllers/cube-controller');

module.exports = (app) => {

    app.get('/', async (req, res) => {
        const cubes = await cubeController.getAllCubes();
        res.render('index', {
            cubes
        });
    });

    app.get('/create', (req, res) => {
        res.render('create');
    });

    app.post('/create', async (req, res) => {
        const newCube = await cubeController.addCube(req.body.name, req.body.description, req.body.difficultyLevel, req.body.imageUrl);
        res.redirect('/');
    });

    app.get('/about', (req, res) => {
        res.render('about');
    });

    app.get('/details/:id', async (req, res) => {
        const cube = await cubeController.getCubeById(req.params.id);
        res.render('details', {
            ...cube,
        });
    });

    app.get('*', (req, res) => {
        res.render('404');
    });
};