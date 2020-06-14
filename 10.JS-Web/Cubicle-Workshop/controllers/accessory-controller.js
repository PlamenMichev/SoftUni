const Accessory = require('../models/accessory');
const Cube = require('../models/cube');

const addAccessory = async (name, imageUrl, description) => {
    const newAccessory = await new Accessory({ name, description, imageUrl }).save();
    return newAccessory;
};

const getAllAccessories = async () => {
    const accessories = await Accessory.find().lean();
    return accessories;
};

const attachAccessory = async (cubeId, accessoryId) => {
    const accessory = await Accessory.findById(accessoryId).lean();
    const cube = await Cube.findByIdAndUpdate(cubeId, {
        $addToSet: {
            Accessoories: [accessory],
        },
    });
    
    return cube;
};

const getAllAccessoriesForCube = async (cubeId) => {
    let accessories = await Accessory.find().lean();
    const cube = await Cube.findById(cubeId).lean();
    
    accessories = accessories.filter((accessory) => {
        return !cube.Accessoories.map(a => a.toString()).includes(accessory._id.toString());
    }); 

    return accessories;
};


module.exports = {
    addAccessory,
    getAllAccessories,
    attachAccessory,
    getAllAccessoriesForCube,
}