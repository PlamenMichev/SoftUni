function aggregate(arr) {
    console.log(`Sum = ${reducer(arr, (a, b) => a + b, 0)}`);
    console.log(`Min = ${reducer(arr, (a, b) => Math.min(a, b), arr[0])}`);
    console.log(`Max = ${reducer(arr, (a, b) => Math.max(a, b), arr[0])}`);
    console.log(`Product = ${reducer(arr, (a, b) => a * b, 1)}`);
    console.log(`Join = ${reducer(arr, (a, b) => '' + a + b, '')}`);

    function reducer(arr, operator, initialValue) {
        let result = initialValue;
        for (let i = 0; i < arr.length; i++) {
            result = operator(result, arr[i]);
        }
        return result;
    }
}

aggregate([5, -3, 20, 7, 0.5]);