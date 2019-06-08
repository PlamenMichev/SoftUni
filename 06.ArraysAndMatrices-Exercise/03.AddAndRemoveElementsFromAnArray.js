function solve(array) {
    let numberToAdd = 0;
    let result = [];
    for (let command of array) {
        if (command === 'add') {
            result.push(numberToAdd + 1);
            numberToAdd += 1;
        } else if (command === 'remove') {
            result.pop();
            numberToAdd += 1;
        }
    }

    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}

solve(['remove', 
'remove', 
'remove']

)