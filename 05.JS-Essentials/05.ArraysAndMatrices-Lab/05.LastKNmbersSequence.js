function solve(firstNum, secNum) {
    let result = [1];
    for (let i = 0; i < firstNum - 1; i++) {
            let sum = 0;

            for (let j = 0; j < secNum; j++) {
                if (j == result.length) {
                    break;
                } else {
                    sum += result[result.length - 1 - j];
                }
            }
            
            result.push(sum);
    }

    console.log(result.join(' '));
}

solve(9, 5);