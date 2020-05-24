function solve(array) {
    let delimeter = array[array.length - 1];
    array.pop();
    console.log(array.join(delimeter));
}

solve(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
)