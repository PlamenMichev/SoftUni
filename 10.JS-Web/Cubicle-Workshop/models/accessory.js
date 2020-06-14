const mongoose = require('mongoose');
const AccessoryScheme = new mongoose.Schema({
    name: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
        maxlength: 200,
    },
    imageUrl: {
        type: String,
        required: true,
    },
    cubes: [{
        type: 'ObjectId',
        ref: 'Cube',
    }]
});

AccessoryScheme.path('imageUrl').validate(function(url) {
    return url.startsWith('http://') || url.startsWith('https://');
});

module.exports = mongoose.model('Accessory', AccessoryScheme);