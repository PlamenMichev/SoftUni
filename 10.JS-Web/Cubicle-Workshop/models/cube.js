const mongoose = require('mongoose');
const CubeScheme = new mongoose.Schema({
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
    difficultyLevel: {
        type: Number,
        required: true,
        min: 1,
        max: 6,
    },
    Accessoories: [{
        type: 'ObjectId',
        ref: 'Accessory',
    }],
    creatorId: {
        type: 'ObjectId',
        ref: 'User',
    },
});

CubeScheme.path('imageUrl').validate(function(url) {
    return url.startsWith('http://') || url.startsWith('https://');
});

module.exports = mongoose.model('Cube', CubeScheme);