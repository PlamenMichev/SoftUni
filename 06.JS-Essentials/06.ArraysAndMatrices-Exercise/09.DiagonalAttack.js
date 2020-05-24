function solve(matrix) {
    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = matrix[row].split(' ').map((e) => {
            return Number(e);
        });
    }

  

    let firstDiagonalSum = 0;
    let secDiagonalSum = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];
            if (row == col) {
                firstDiagonalSum += element;
            }
            if (col + row == matrix.length - 1) {
                secDiagonalSum += element;
            }
        }
    }

    if (firstDiagonalSum === secDiagonalSum) {

        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                const element = matrix[row][col];
                if (!(row == col || col + row == matrix.length - 1)) {
                    matrix[row][col] = firstDiagonalSum;
                }
            }
        }

        for (let row = 0; row < matrix.length; row++) {
            matrix[row] = matrix[row].join(' ');
        }

        console.log(matrix.join('\n'))      
    } else {
        for (let row = 0; row < matrix.length; row++) {
            matrix[row] = matrix[row].join(' ');
        }

        console.log(matrix.join('\n')) 
    }


}

solve(['1 1 1',
'1 1 1',
'1 1 0']

)