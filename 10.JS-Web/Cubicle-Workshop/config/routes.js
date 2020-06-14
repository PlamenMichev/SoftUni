const cubeController = require('../controllers/cube-controller');
const accessoryController = require('../controllers/accessory-controller');

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

    app.get('/create/accessory', (req, res) => {
        res.render('createAccessory');
    });

    app.post('/create/accessory', async (req, res) => {
        try {
            const newAccessory = await accessoryController.addAccessory(req.body.name, req.body.imageUrl, req.body.description);
            res.redirect('/');
        } catch (error) {
            res.render('createAccessory');
        }
    });

    app.get('/attach/accessory/:id', async (req, res) => {
        const cube = await cubeController.getCubeById(req.params.id);
        const accessories = await accessoryController.getAllAccessoriesForCube(cube._id);
        res.render('attachAccessory', {
            cube,
            accessories,
        });
    });

    app.post('/attach/accessory/:id', async (req, res) => {
        try {
            await accessoryController.attachAccessory(req.params.id, req.body.accessory);
            res.redirect('/');
        } catch (error) {
            res.redirect('/')
        }
    });

    app.get('*', (req, res) => {
        res.render('404');
    });
};