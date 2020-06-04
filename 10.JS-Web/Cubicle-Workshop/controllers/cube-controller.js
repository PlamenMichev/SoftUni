const Cube = require('../models/cube');
const fs = require('fs');
const path = require('path');

const databasePath = path.join(__dirname, '../config/database.json');

const addCube = (name, description, difficultyLevel, imageUrl) => {
    const newCube = new Cube(name, description, imageUrl, difficultyLevel);
    newCube.save();

    return newCube;
};

const getAllCubes = (callback) => {
    fs.readFile(databasePath, (err, data) => {
        if (err) {
            throw err;
        }

        const currentCubes = JSON.parse(data);
        return callback(currentCubes);
    });
};

const getCubeById = (id, callback) => {
    fs.readFile(databasePath, (err, data) => {
        if (err) {
            throw err;
        }

        const currentCubes = JSON.parse(data);
        const cube = currentCubes.filter(c => c.id === id)[0];
        return callback(cube);
    });
};

module.exports = {
    addCube,
    getAllCubes,
    getCubeById,
};