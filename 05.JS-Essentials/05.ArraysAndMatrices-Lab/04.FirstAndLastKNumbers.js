function solve(params) {
    let length = params[0];
    let firstLineResult = '';
    let secLineResult = '';
    for (let i = 1; i <= length; i++) {
        const element = params[i];
        firstLineResult += element + ' ';
    }

    for (let i = params.length - length; i < params.length ; i++) {
        const element = params[i];
        secLineResult += element + ' ';
        
    }

    console.log(firstLineResult);
    console.log(secLineResult);
}

solve([3,
    6, 7, 8, 9]
   )