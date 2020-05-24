function getFibonator() {
    let currentNum = 1;
    let previousNum = 0;

    let result = function getNumber() {
        let currentResult = currentNum;
        currentNum += previousNum;
        previousNum = currentResult;
        return currentResult;
    }

    return result;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
