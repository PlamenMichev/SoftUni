function solve(params) {
    let count = 0;
    for (let row = 0; row < params.length; row++) {
        for (let col = 0; col < params[row].length; col++) {
            const element = params[row][col];
            if (params.length - 1 > row) {
                if (element === params[row + 1][col]) {
                    count++;
                }
            }
                if (element === params[row][col + 1]){
                    count++;
                }

            
        }
    }

    console.log(count);
}

solve([[2, 2, 5, 7, 4], 
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]);