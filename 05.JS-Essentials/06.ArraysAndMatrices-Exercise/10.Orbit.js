function solve(params) {
    let rows = params[0];
    let cols = params[1];
    let initialRow = params[2];
    let initialCol = params[3];
    let matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = 0;
        }
    }

    matrix[initialRow][initialCol] = 1;
    let numToAdd = 2;
    while (!isOver(matrix)) {
        if (initialRow - (numToAdd - 1) >= 0) {
            matrix[initialRow - (numToAdd - 1)][initialCol] = numToAdd;
        }

        if (initialRow + (numToAdd - 1) < rows) {
            matrix[initialRow + (numToAdd - 1)][initialCol] = numToAdd;
        }

        if (initialCol + (numToAdd - 1) < cols) {
            matrix[initialRow][initialCol + (numToAdd - 1)] = numToAdd;
        }

        if (initialCol - (numToAdd - 1) >= 0) {
            matrix[initialRow][initialCol - (numToAdd - 1)] = numToAdd;
        }

        if (initialRow - (numToAdd - 1) >= 0 && initialCol - (numToAdd - 1) >= 0) {
            matrix[initialRow - (numToAdd - 1)][initialCol - (numToAdd - 1)] = numToAdd;
            matrix[initialRow - (numToAdd - 1) + 1][initialCol - (numToAdd - 1)] = numToAdd;
            matrix[initialRow - (numToAdd - 1)][initialCol - (numToAdd - 1) + 1] = numToAdd;

        }

        if (initialRow + (numToAdd - 1) < rows && initialCol + (numToAdd - 1) < cols) {
            matrix[initialRow + (numToAdd - 1)][initialCol + (numToAdd - 1)] = numToAdd;
            matrix[initialRow + (numToAdd - 1) - 1][initialCol + (numToAdd - 1)] = numToAdd;
            matrix[initialRow + (numToAdd - 1)][initialCol + (numToAdd - 1) - 1] = numToAdd;

        }

        if (initialRow - (numToAdd - 1) >= 0 && initialCol + (numToAdd - 1) < cols) {
            matrix[initialRow - (numToAdd - 1)][initialCol + (numToAdd - 1)] = numToAdd;
            matrix[initialRow - (numToAdd - 1) + 1][initialCol + (numToAdd - 1)] = numToAdd;
            matrix[initialRow - (numToAdd - 1)][initialCol + (numToAdd - 1) - 1] = numToAdd;
        }

        if (initialRow + (numToAdd - 1) < rows && initialCol - (numToAdd - 1) >= 0) {
            matrix[initialRow + (numToAdd - 1)][initialCol - (numToAdd - 1)] = numToAdd;
            matrix[initialRow + (numToAdd - 1) - 1][initialCol - (numToAdd - 1)] = numToAdd;
            matrix[initialRow + (numToAdd - 1)][initialCol - (numToAdd - 1) + 1] = numToAdd;
        }    
        numToAdd++;       
    }

    for (let arr of matrix) {
        console.log(arr.join(' '));
    }

    function isOver(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                const element = matrix[row][col];
                if (element === 0) {
                    return false;
                }
            }
        }

        return true;
    }
}

solve([3, 3, 0, 0])