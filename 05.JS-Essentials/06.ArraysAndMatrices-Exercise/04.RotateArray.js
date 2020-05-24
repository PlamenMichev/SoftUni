function solve(array) {
    let rotations = Number(array[array.length - 1]);
    array.pop();
    for (let i = 0; i < rotations % array.length; i++) {
        const element = array[array.length - 1];      
        array.unshift(element);
        array.pop();
    }

    console.log(array.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']

)