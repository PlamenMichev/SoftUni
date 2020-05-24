function townsToJson(input) {
    let towns = [];
    let result = [];
    let regex = /\s*\|\s*/;
    for (let i = 1; i < input.length; i++) {
        const element = input[i];
        let args = element.split(regex);
        let obj = { Town: args[1], Latitude: Number(args[2]), Longitude: Number(args[3])};
        towns.push(obj);
    }

    console.log(JSON.stringify(towns));
}

townsToJson(['| Town | Latitude | Longitude |', '| Sofia | 42.696552 | 23.32601 |', '| Beijing | 39.913818 | 116.363625 |']);