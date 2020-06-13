const Cube = require('../models/cube');

const addCube = async (name, description, difficultyLevel, imageUrl) => {
    const newCube = await new Cube({ name, description, imageUrl, difficultyLevel }).save();
    console.log('Cube: ', newCube);

    return newCube;
};

const getAllCubes = async () => {
    const cubes = await Cube.find().lean();
    return cubes;
};

const getCubeById = async (id) => {
    const cube = await Cube.findById(id).lean();
    return cube;
};

module.exports = {
    addCube,
    getAllCubes,
    getCubeById,
};