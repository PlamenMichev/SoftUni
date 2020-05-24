function solve(rows, cols) {
    let maxNum = rows * cols;
    let result = [];
    for (let i = 0; i < rows; i++) {
        result[i] = [];
    }

    let currentUpperRow = 0;
    let currentDownRow = rows - 1;
    let currentRightCol = cols - 1;
    let currentLeftCol = 0;
    let numToAdd = 1;

    for (let i = 0; i < rows/2; i++) {
        
        for (let col = currentLeftCol; col < currentRightCol; col++) {
            result[currentUpperRow][col] = numToAdd;
            numToAdd++;
        }

        for (let row = currentUpperRow; row < currentRightCol; row++) {
            result[row][currentRightCol] = numToAdd;
            numToAdd++;
        }

        for (let col = currentRightCol; col > currentLeftCol; col--) {
            result[currentDownRow][col] = numToAdd;
            numToAdd++;
        }

        for (let row = currentDownRow; row > currentUpperRow; row--) {
            result[row][currentLeftCol] = numToAdd;
            numToAdd++;
        }

        currentUpperRow++;
       
        currentRightCol--;
        
        currentDownRow--;
        
        currentLeftCol++;

    }

    if (rows % 2 !== 0) {
        let row = Math.floor(rows/2);
    let col = Math.floor(cols/2);
    result[row][col] = numToAdd;
    }
    for(let row of result) {
        console.log(row.join(' '));
    }
}

solve(5, 3);