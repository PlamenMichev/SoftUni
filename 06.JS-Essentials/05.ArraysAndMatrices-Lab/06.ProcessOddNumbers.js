function solve(params) {
    let oddNumbers = [];

    for (let i = 0; i < params.length; i++) {
        const element = params[i];
        if (i % 2 != 0) {
            oddNumbers.push(element);
        }
    }

    oddNumbers = oddNumbers.map((e) => {
        return e * 2;
    });

    oddNumbers.reverse();
    console.log(oddNumbers.join(' '));
}

solve([3, 0, 10, 4, 7, 3]);