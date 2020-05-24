function solve(array) {
    let steps = Number(array[array.length - 1]);
    array.pop();
    for (let i = 0; i < array.length; i+=steps) {
        const element = array[i];
        console.log(element);
    }
}
