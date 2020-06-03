const { v4 } = require('uuid');
const fs = require('fs');
const path = require('path');

const databasePath = path.join(__dirname, '../config/database.json');

class Cube {
    constructor (name, description, imageUrl, difficultyLevel) {
        this.id = v4();
        this.name = name || 'No name';
        this.description = description;
        this.imageUrl = imageUrl || 'default image url';
        this.difficultyLevel = difficultyLevel || 0;
    }

    save() {
        const cubeData = {
            id: this.id,
            name: this.name,
            description: this.description,
            imageUrl: this.imageUrl,
            difficultyLevel = this.difficultyLevel,
        };

        fs.readFile(databasePath, (err, data) => {
            if (err) {
                throw err;
            }

            const currentCubes = JSON.parse(data);
            currentCubes.push(cubeData);

            fs.writeFile(databasePath, JSON.stringify(currentCubes), err => {
                if (err) {
                    throw err;
                }
    
                console.log('New cube was added');
            });
        });
    }
}

module.exports = Cube;