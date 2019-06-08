function solve(params) {
    params.sort((a, b) => {
        return a - b;
    });

    console.log(params[0] + ' ' + params[1]);
}

solve([30, 15, 50, 5]);