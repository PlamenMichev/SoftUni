function solve(matrix) {
    let sum = 0;
    for (let i = 0; i < 1; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            sum += matrix[i][j];
        }
    }

    let isMagic = true;

    for (let row = 0; row < matrix.length; row++) {
        let currentSum = 0
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];
            currentSum += element;
        }

        if (currentSum !== sum) {
            isMagic = false;
            break;
        }
    }

    let rows = matrix[0].length;
    for (let row = 0; row < rows; row++) {
        let currentSum = 0
        for (let col = 0; col < matrix.length; col++) {
            const element = matrix[col][row];
            currentSum += element;
        }

        if (currentSum !== sum) {
            isMagic = false;
            break;
        }
    }
    console.log(isMagic);
}

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
      );