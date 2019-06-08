function solve(orders) {
    let totalMoney = 0;
    for (let i = 0; i < orders.length; i++) {
        const order = orders[i].split(', ');
        let price = 0;
        let coins = Number(order[0]);
        let typeOfDrink = order[1];

        if (typeOfDrink == 'coffee') {
            let typeOfCoffee = order[2];
            if (typeOfCoffee == 'caffeine') {
                price += 0.8;
            } else {
                price += 0.9;
            } 

            let milk = order[3];
            if (milk == 'milk') {
                price += Number((0.1 * price).toFixed(1));
                let sugar = Number(order[4]);
                if (sugar != 0) {
                    price += 0.10;
                }
            } else {
                let sugar = Number(order[3]);
                if (sugar != 0) {
                    price += 0.10;
                }
            }
        } else {
            price += 0.80;
            let milk = order[2];
            if (milk == 'milk') {
                price += Number((0.1 * price).toFixed(1));
                let sugar = Number(order[3]);
                if (sugar != 0) {
                    price += 0.10;
                }
            } else {
                let sugar = Number(order[2]);
                if (sugar != 0) {
                    price += 0.10;
                }
            }
        }

        if (coins >= price) {
            console.log(`You ordered ${typeOfDrink}. Price: ${price.toFixed(2)}$ Change: ${(coins - price).toFixed(2)}$`);
            totalMoney += price;
        } else {
            console.log(`Not enough money for ${typeOfDrink}. Need ${(price - coins).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`)

}

solve(['8.00, coffee, decaf, 4',
'1.00, tea, 2']

)