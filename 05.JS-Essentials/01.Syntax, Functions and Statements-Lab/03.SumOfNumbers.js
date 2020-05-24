function calculateNums(firstNumString, secNumString) {
    let firstNum = Number(firstNumString);
    let secNum = Number(secNumString);
    let total = 0;

    for (let i = firstNum; i <= secNumString; i++) {
        total += i;
    }

    console.log(total);
}

calculateNums('-8', '20');