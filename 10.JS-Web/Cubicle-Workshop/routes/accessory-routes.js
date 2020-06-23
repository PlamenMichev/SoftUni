const accessoryController = require('../controllers/accessory-controller');
const cubeController = require('../controllers/cube-controller');

module.exports = (app) => {
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
};