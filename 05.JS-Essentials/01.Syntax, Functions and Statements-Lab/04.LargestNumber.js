function findLargestNum(firstNum, secNum, thirdNum) {
    let result = 0;

    if (firstNum < secNum) {
        if (secNum < thirdNum) {
            result = thirdNum;
        }
        else {
            result = secNum;
        }
    }
    else {
        if (firstNum < thirdNum) {
            result = thirdNum;
        }
        else {
            result = firstNum;
        }
    }

    console.log(`The largest number is ${result}.`);
}

findLargestNum(-3, -5, -22.5);