const User = require('../models/user');
const bcrypt = require('bcrypt');
const saltRounds = 10;
const jwt = require('jsonwebtoken');
const privateKey = 'very secret key!';

const addUser = async (username, password) => {
    const salt = await bcrypt.genSalt(saltRounds);
    const hashedPassword = await bcrypt.hash(password, salt);
    const newUser = User({username, password: hashedPassword});
    const user = newUser.save();

    return user;
};

const isUserValid = async (username, password) => {
    let result = false;
    const user = await User.findOne({'username': username});
    if (user && await bcrypt.compare(password, user.password)) {
        result = true;    
    }

    return result;
};

// Middlewares
const isAuthenticated = (req, res, next) => {
    try {
        const isValid = jwt.verify(req.cookies.auth, privateKey);
        if (!isValid) {
            res.redirect('/login');
        } else {
            next();
        }
    } catch (error) {
        res.redirect('/login');
    }
};

const checkLoggedInUser = (req, res, next) => {
    try {
        const isValid = jwt.verify(req.cookies.auth, privateKey);
        if (!isValid) {
            next();
        } else {
            res.redirect('/');
        }
    } catch (error) {
        next();
    }
};

const isLoggedIn = (req, res, next) => {
    try {
        const isValid = jwt.verify(req.cookies.auth, privateKey);
        if (isValid) {
            req.isLoggedIn =  true;
            next();
        } else {
            req.isLoggedIn = false;
            next();
        }
    } catch (error) {
        req.isLoggedIn = false;
        next();
    }
};

module.exports = {
    addUser,
    isUserValid,
    isAuthenticated,
    checkLoggedInUser,
    isLoggedIn,
};