function solve(fruits) {
    let cherryKompots = 0;
    let numberOfCharies = 0;
    let peachKompots = 0;
    let numberOfPeaches = 0;
    let plumKompots = 0;
    numberOfPlums = 0;
    let rakiya = 0;
    let frutisForRakiya = 0;
    for (let fruitArgs of fruits) {
        fruitArgs = fruitArgs.split(/\s+/gm);
        let fruit = fruitArgs[0];
        let weightInKg = +fruitArgs[1];
        let weightInGrams = weightInKg * 1000;
        if (fruit === 'cherry') {
            numberOfCharies += weightInGrams / 9;
            cherryKompots += Math.floor(numberOfCharies / 25);
            numberOfCharies = (numberOfCharies % 25);
        } else if (fruit === 'peach'){
            numberOfPeaches += weightInGrams / 140;
            peachKompots += Math.floor(numberOfPeaches / 2.5);
            numberOfPeaches = (numberOfPeaches % 2.5);
        } else if (fruit === 'plum'){
            numberOfPlums += weightInGrams / 20;
            plumKompots += Math.floor(numberOfPlums / 10);
            numberOfPlums = (numberOfPlums % 10);
        }  else {
            frutisForRakiya += weightInGrams;
        }
    }

    rakiya = frutisForRakiya / 1000;
    rakiya = rakiya * 0.200;
    console.log(`Cherry kompots: ${cherryKompots}`);
    console.log(`Peach kompots: ${peachKompots}`);
    console.log(`Plum kompots: ${plumKompots}`);
    console.log(`Rakiya liters: ${rakiya.toFixed(2)}`);
}

solve([   'apple 6',
'peach 25.158',
'strawberry 0.200',
'peach 0.1',
'banana 1.55',
'cherry 20.5',
'banana 16.8',
'grapes 205.65'
,'watermelon 20.54'
]
)