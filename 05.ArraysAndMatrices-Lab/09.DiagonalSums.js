function solve(params) {
    let firstSum = 0;
    let secSum = 0;
    for (let row = 0; row < params.length; row++) {
        for (let col = 0; col < params[row].length; col++) {
            const element = params[row][col];
            if (row == col) {
                firstSum += element;
            }
            if (col + row == params.length - 1) {
                secSum += element;
            }
        }
    }

    console.log(firstSum + ' ' + secSum);
}

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   )