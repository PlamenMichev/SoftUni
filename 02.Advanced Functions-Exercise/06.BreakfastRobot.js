function solution() {
    let protein = 0;
    let carbohydrates = 0;
    let fat = 0;
    let flavours = 0;

    function manager(commandArgsString) {
        let commandArgs = commandArgsString.split(' ');
        let command = commandArgs[0];

        if (command === 'restock') {
            let element = commandArgs[1];
            let quantity = +commandArgs[2];

            switch (element) {
                case 'carbohydrate': {
                    carbohydrates += quantity;
                    break;
                }
                case 'flavour': {
                    flavours += quantity;
                    break;
                }
                case 'fat': {
                    fat += quantity;
                    break;
                }
                case 'protein': {
                    protein += quantity;
                    break;
                }
            }

            return "Success";
        } else if (command === 'report') {
            return `protein=${protein} carbohydrate=${carbohydrates} fat=${fat} flavour=${flavours}`;
        } else {
            let element = commandArgs[1];
            let quantity = +commandArgs[2];
            let isAvaible = true;
            let notEnoughMaterial = '';
            switch (element) {
                case 'apple': {
                    if (carbohydrates < 1 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'carbohydrate';
                    } else if (flavours < 2 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'flavour';
                    }
                    break;
                }
                case 'lemonade': {
                    if (carbohydrates < 10 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'carbohydrate';
                    } else if (flavours < 20 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'flavour';
                    }

                    break;
                }
                case 'burger': {
                    if (carbohydrates < 5 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'carbohydrate';
                    } else if (fat < 7 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'fat';
                    } else if (flavours < 3 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'flavour';
                    }

                    break;
                }
                case 'eggs': {
                    if (protein < 5 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'protein';
                    } else if (fat < 1 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'fat';
                    } else if (flavours < 1 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'flavour';
                    }

                    break;
                }
                case 'turkey': {
                    if (protein < 10 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'protein';
                    } else if (carbohydrates < 10 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'carbohydrate';
                    } else if (fat < 10 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'fat';
                    } else if (flavours < 10 * quantity) {
                        isAvaible = false;
                        notEnoughMaterial = 'flavour';
                    }

                    break;
                }
            }

            if (isAvaible === false) {
                return `Error: not enough ${notEnoughMaterial} in stock`;
            } else {
                switch (element) {
                    case 'apple': {
                        carbohydrates -= 1 * quantity;
                        flavours -= 2 * quantity;
                        break;
                    }
                    case 'lemonade': {
                        carbohydrates -= 10 * quantity;
                        flavours -= 20 * quantity;

                        break;
                    }
                    case 'burger': {
                        carbohydrates -= 5 * quantity;
                        fat -= 7 * quantity;
                        flavours -= 3 * quantity;

                        break;
                    }
                    case 'eggs': {
                        protein -= 5 * quantity;
                        fat -= 1 * quantity;
                        flavours -= 1 * quantity;

                        break;
                    }
                    case 'turkey': {
                        protein -= 10 * quantity;
                        carbohydrates -= 10 * quantity;
                        fat -= 10 * quantity;
                        flavours -= 10 * quantity;

                        break;
                    }
                }

                return 'Success';
            }
        }

        
    }
    return manager;
}

    let manager = solution();
    manager("prepare turkey 1");  
    manager("restock protein 10");  
    manager("prepare turkey 1");  
    manager("restock carbohydrate 10");  
    manager("prepare turkey 1");  
    manager("restock fat 10");  
    manager("prepare turkey 1"); 
    manager("restock flavour 10"); 
    manager("prepare turkey 1"); 
    manager("report"); 
    
