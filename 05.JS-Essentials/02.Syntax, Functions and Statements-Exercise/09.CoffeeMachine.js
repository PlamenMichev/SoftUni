function coffeeMachine(input) {
    let length = input.length;
    let totalIncome = 0;
    for (let i = 0; i < input.length; i++) {
        const order = input[i].split(', ');
        let price = 0;
        let paid = Number(order[0]);
        let drink = order[1];
        if (drink == 'coffee') {
            let type = order[2];
            if (type == 'caffeine') {
                price += 0.80;
            } else {
                price += 0.90;
            }
            let milk = Number(order[3]);
            if (Number.isInteger(milk)) {
                let sugarAmount = Number(milk);
                if (sugarAmount != 0) {
                    price += 0.10;
                }
            } else {
                let milkPrice = (0.10 * price).toFixed(1);
                price += Number(milkPrice);
                let sugarAmount = Number(order[4]);
                if (sugarAmount != 0) {
                    price += 0.10;
                }
            }
        }
        else {
            price += 0.80;
            let milk = Number(order[2]);
            if (Number.isInteger(milk)) {
                let sugarAmount = Number(milk);
                if (sugarAmount != 0) {
                    price += 0.10;
                }
            } else {
                let milkPrice = (0.10 * price).toFixed(1);
                price += Number(milkPrice);
                let sugarAmount = Number(order[3]);
                if (sugarAmount != 0) {
                    price += 0.10;
                }
            }
        }

        if (paid - price >= 0) {
            console.log(`You ordered ${drink}. Price: $${price.toFixed(2)} Change: $${(paid - price).toFixed(2)}`);
            totalIncome += price;
        } else {
            console.log(`Not enough money for ${drink}. Need $${(price - paid).toFixed(2)} more.`);
        }
    }
    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);