function solve(carObj) {
    let engines = {
        smallEngine: { power: 90, volume: 1800 },
        normalEngine: { power: 120, volume: 2400 },
        monsterEngine: { power: 200, volume: 3500 }
    }

    let carriages = {
        hatchback: { type: 'hatchback', color: '' },
        coupe: { type: 'coupe', color: '' },
    }

    let result = {
        model: carObj.model,
    }

    for (let engine of Object.keys(engines)) {
        if (engines[engine].power >= carObj.power) {
            result.engine = engines[engine];
            break;
        } 
    }

    for (let carriage of Object.keys(carriages)) {
        if (carriage === carObj.carriage) {
            carriages[carriage].color = carObj.color;
            result.carriage = carriages[carriage];
        } 
    }

    if (carObj.wheelsize % 2 === 0) {
        result.wheels = [carObj.wheelsize - 1, carObj.wheelsize - 1, carObj.wheelsize - 1, carObj.wheelsize - 1];
    } else {
        result.wheels = [carObj.wheelsize, carObj.wheelsize, carObj.wheelsize, carObj.wheelsize];
    }

    return result;
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
))