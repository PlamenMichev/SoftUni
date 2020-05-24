function coffeeStorage() {
    let insptectionElement = document.getElementsByTagName('p')[1];

    let brands = {};
    let inputBoxValue = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    for (let coffee of inputBoxValue) {
        coffee = coffee.split(', ');
        let command = coffee[0];
        let brand = coffee[1];
        let coffeeType = coffee[2];
        let expireDate = coffee[3];
        let quantity = coffee[4];
        if (command === 'IN') {
            if (!brands[brand]) {
                brands[brand] = {};
            }
            if (!brands[brand][coffeeType]) {
                brands[brand][coffeeType] = {expireDate: expireDate, quantity: Number(quantity)};
            }

            if (expireDate > brands[brand][coffeeType].expireDate) {
                brands[brand][coffeeType] = {expireDate: expireDate, quantity: Number(quantity)};                
            }
            if (expireDate === brands[brand][coffeeType].expireDate) {
                brands[brand][coffeeType] = {expireDate: expireDate, quantity: Number(quantity)};
            }
        }
        if (command === 'OUT') {
            if (brands[brand] && brands[brand][coffeeType]) {
                console.log(brands[brand][coffeeType].quantity, Number(quantity));
                if (brands[brand][coffeeType].expireDate > expireDate && brands[brand][coffeeType].quantity >= Number(quantity)) {
                    brands[brand][coffeeType].quantity -= Number(quantity);
                    console.log(12);
                }
            }
        }
        if (command === 'REPORT') {
            let reportElement = document.getElementsByTagName('p')[0];
            console.log(reportElement);
            for (let brand in brands) {
                let currentElement = document.createElement('p');
                let currentString = brand + ': ';
                for (coffee in brands[brand]) {
                    currentString += coffee + ' - ' + brands[brand][coffee].expireDate + ' - ' + brands[brand][coffee].quantity + '. ';
                }

                currentElement.textContent = currentString.trim();
                reportElement.appendChild(currentElement);
            }
        }
        if (command === 'INSPECTION') {
            console.log(insptectionElement);
            let brandsArray = [];
            let coffeesArray = [];
            for(let brand in brands) {
                brandsArray.push(brand);
            }
            brandsArray = brandsArray.sort((a, b) => {
                return a.localeCompare(b);
            });
            for (let brand of brandsArray) {
                let currentElement = document.createElement('p');
                let currentString = brand + ': ';
                for (let coffee in brands[brand]) {
                    coffeesArray.push(coffee);
                }
                coffeesArray = coffeesArray.sort((a, b) => {
                    return brands[brand][b].quantity - brands[brand][a].quantity;
                })
                for (let coffee of coffeesArray) {                       
                    console.log(brand, coffee)
                    console.log(brands[brand][coffee]);
                    currentString += coffee + ' - ' + brands[brand][coffee].expireDate + ' - ' + brands[brand][coffee].quantity + '. ';
                }

                coffeesArray = [];
                currentElement.textContent = currentString.trim();
                insptectionElement.appendChild(currentElement);
            }
        }
    }



}
