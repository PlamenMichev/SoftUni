function SumByTown(params) {
    let towns = {};
    for (let i = 0; i < params.length; i+=2) {
        const element = params[i];
        if (!towns[params[i]]) {
            towns[params[i]] = 0;
        }

        towns[params[i]] += Number(params[i + 1]);
    }

    console.log(JSON.stringify(towns));
}

SumByTown(['Sofia',
    "20",
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4',
    ])