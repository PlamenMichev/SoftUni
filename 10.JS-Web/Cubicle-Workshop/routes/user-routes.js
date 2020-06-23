const userController = require('../controllers/user-controller.js');
const jwt = require('jsonwebtoken');
const privateKey = 'very secret key!';

module.exports = (app) => {
    app.get('/login', userController.checkLoggedInUser, userController.isLoggedIn, (req, res) => {
        res.render('loginPage', {
            isLoggedIn: req.isLoggedIn,
        });
    });

    app.post('/login', userController.checkLoggedInUser, async (req, res) => {
        const isValidUser = await userController.isUserValid(req.body.username, req.body.password);
        if (isValidUser) {
            
            const token = jwt.sign({
                username: req.body.username,
                password: req.body.password,
            }, privateKey);
    
            res.cookie('auth', token);
            res.redirect('/');
        } else {
            res.redirect('/register');
        }
    });

    app.get('/register', userController.checkLoggedInUser, userController.isLoggedIn, (req, res) => {
        res.render('registerPage', {
            isLoggedIn: req.isLoggedIn,
        });
    });

    app.post('/register', userController.checkLoggedInUser, async (req, res) => {
        try {
            const user = await userController.addUser(req.body.username, req.body.password);
            const token = jwt.sign({
                username: user.username,
                password: user.password,
            }, privateKey);

            res.cookie('auth', token);
            res.redirect('/'); 
        } catch (error) {
            res.redirect('/register');
            
        }
    });

    app.get('/logout', (req, res) => {
        res.clearCookie('auth');
        res.redirect('/');
    });
};