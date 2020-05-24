function cookingByNumbers(input) {
    let num = Number(input[0]);
    for (let i = 1; i < input.length; i++) {
        const element = input[i];
        switch (element) {
            case 'chop': {
                num /= 2;
                break;
            }
            case 'dice': {
                num /= Math.sqrt(num);
                break;
            } 
            case 'spice': {
                num += 1;
                break;
            }  
            case 'bake': {
                num *= 3;
                break;
            }  
            case 'fillet': {
                num -= 0.2 * num;
                break;
            } 
        }

        console.log(num);
    }
}

cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);