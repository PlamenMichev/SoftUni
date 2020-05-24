function solve(params) {
    let result = [];
    for (let i = 0; i < params.length; i++) {
        const element = params[i];
        if (element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    }

    console.log(result.join('\n'));
}

solve([7, -2, 8, 9]);