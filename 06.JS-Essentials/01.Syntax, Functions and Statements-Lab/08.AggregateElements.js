function aggregate(params) {
    let sum = 0;
    for (let number of params) {
        sum += number;
    }

    let secSum = 0;

    for (let number of params) {
        secSum += 1/number;
    }

    let thirdResult = '';

    for (let number of params) {
        thirdResult += number;
    }

    console.log(sum);
    console.log(secSum);
    console.log(thirdResult);
}

aggregate([2, 4, 8, 16]);