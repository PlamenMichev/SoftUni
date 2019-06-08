function solve(params) {
    let maxNum = params[0][0];
    for (let array of params) {
        array.sort((a, b) => {
            return b - a;
        });
    
        if (array[0] >= maxNum) {
            maxNum = array[0];
        }
    }
    
    console.log(maxNum);
}

solve([]);