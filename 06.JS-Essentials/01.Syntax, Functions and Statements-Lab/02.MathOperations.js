function calculateNums(firstNum, secNum, operator) {
    switch (operator) {
        case '+': {
            console.log(firstNum + secNum);
            break;
        }
        case '-': {
            console.log(firstNum - secNum);
            break;
        }
        case '*': {
            console.log(firstNum * secNum);
            break;
        }
        case '/': {
            console.log(firstNum / secNum);
            break;
        }
        case '%': {
            console.log(firstNum % secNum);
            break;
        }
        case '**': {
            console.log(firstNum ** secNum);
            break;
        }
    }
}

calculateNums(3, 3, '/');