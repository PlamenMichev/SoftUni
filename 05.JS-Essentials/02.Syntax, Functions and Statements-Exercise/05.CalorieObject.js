function calculateCalories(input) {
    let length = input.length;
    let result = [];
    let output = '{ ';
    for (let i = 0; i < length - 1; i+=2) {
        const element = input[i];
        result[element] = input[i + 1];
        if (i == length - 2) {
            output += element + ': ' + result[element] + ' ';
        } else {
            output += element + ': ' + result[element] + ', ';
        }
    }

    output += '}';  
    console.log(output);
    
}

calculateCalories(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);