const cubeController = require('../controllers/cube-controller');

module.exports = (app) => {

    app.get('/', (req, res) => {
        cubeController.getAllCubes((cubes) => {
            res.render('index', {
                cubes
            });
        });
    });

    app.get('/create', (req, res) => {
        res.render('create');
    });

    app.post('/create', (req, res) => {
        const newCube = cubeController.addCube(req.body.name, req.body.description, req.body.difficultyLevel, req.body.imageUrl);
        res.redirect('/');
    });

    app.get('/about', (req, res) => {
        res.render('about');
    });

    app.get('/details/:id', (req, res) => {
        cubeController.getCubeById(req.params.id, (cube) => {
            res.render('details', {
                ...cube,
            });
        });
    });

    app.get('*', (req, res) => {
        res.render('404');
    });
};