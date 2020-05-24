function findPopulation(params) {
    let result = {};
    let count = 0;
    for (let i = 0; i < params.length; i++) {
        let element = params[i].split(' <-> ');
        if (!result[element[0]]) {
            result[element[0]] = 0;
            count++;
        }

        let num = Number(element[1]);
        result[element[0]] += num;
    }

    for (town in result) {
        console.log(`${town} : ${result[town]}`)
    }
}

findPopulation(['Istanbul <-> 100000',
    'Istanbul <-> 1000'
    ])