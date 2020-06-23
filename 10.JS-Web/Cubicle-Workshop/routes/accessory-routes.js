const accessoryController = require('../controllers/accessory-controller');
const cubeController = require('../controllers/cube-controller');
const { isAuthenticated, isLoggedIn } = require('../controllers/user-controller');

module.exports = (app) => {
    app.get('/create/accessory', isAuthenticated, isLoggedIn, (req, res) => {
        res.render('createAccessory', {
            isLoggedIn: req.isLoggedIn,
        });
    });

    app.post('/create/accessory', isAuthenticated, isLoggedIn, async (req, res) => {
        try {
            const newAccessory = await accessoryController.addAccessory(req.body.name, req.body.imageUrl, req.body.description);
            res.redirect('/');
        } catch (error) {
            res.render('createAccessory', {
                isLoggedIn: req.isLoggedIn,
            });
        }
    });

    app.get('/attach/accessory/:id', isAuthenticated, isLoggedIn, async (req, res) => {
        const cube = await cubeController.getCubeById(req.params.id);
        const accessories = await accessoryController.getAllAccessoriesForCube(cube._id);
        res.render('attachAccessory', {
            cube,
            accessories,
            isLoggedIn: req.isLoggedIn,
        });
    });

    app.post('/attach/accessory/:id', isAuthenticated, async (req, res) => {
        try {
            await accessoryController.attachAccessory(req.params.id, req.body.accessory);
            res.redirect('/');
        } catch (error) {
            res.redirect('/')
        }
    });
};