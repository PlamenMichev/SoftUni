function findGCD(firstNum, secNum) {
    let left = 0;
    while(secNum != 0) {
        left = firstNum % secNum;
        firstNum = secNum;
        secNum = left;
    }
    
    console.log(firstNum);
} 

findGCD(2154, 458);