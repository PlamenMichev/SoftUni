function solve(array) {
    let firstElement = array[0];
    let result = [firstElement];
    for (let i = 1; i < array.length; i++) {
        const element = array[i];
        if (element >= firstElement) {
            result.push(element);
            firstElement = array[i];
        }

    }
    console.log(result.join('\n'));
}

solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
       
    );