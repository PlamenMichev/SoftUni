function solve(params) {
    let cars = [];

    for (let i = 0; i < params.length; i++) {
        const element = params[i].split(' ');
        let command = element[0];
        if (command === 'create') {
            if (element.length === 4) {
                let newCar = Object.create(cars[element[3]]);
                newCar.name = element[1];
                cars[element[1]] = newCar;

            } else {
                let newCar = {
                    name: element[1]
                }

                cars[element[1]] = newCar;
            }
        }

        if (command === 'set') {
            let car = cars[element[1]];
            car[element[2]] = element[3];
        }

        if (command === 'print') {
            let carToPrint = cars[element[1]];
            let result = [];
            for (let key of Object.keys(carToPrint)) {
                result.push(`${key}:${carToPrint[key]}`);
            }

            let proto = Object.getPrototypeOf(carToPrint);
            while(proto) {

                for (let i = 1; i < Object.keys(proto).length; i++) {
                    const element = Object.keys(proto)[i];
                    result.push(`${element}:${carToPrint[element]}`);
                }

                proto = Object.getPrototypeOf(proto);
            }


            result = result.slice(1, result.length);
            console.log(result.join(', '))
        }
    }
}

solve(['create pesho','create gosho inherit pesho','create stamat inherit gosho','set pesho rank number1','set gosho nick goshko','print stamat'])