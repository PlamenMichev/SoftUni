function solve(arr, startIndex, lastIndex) {
    if (Array.isArray(arr) === false) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (lastIndex >= arr.length) {
        lastIndex = arr.length - 1;
    }

    let sum = 0;
    arr = arr.map(Number);

    for (let i = startIndex; i <= lastIndex; i++) {
        const num = arr[i];
        sum += num;
    }

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));