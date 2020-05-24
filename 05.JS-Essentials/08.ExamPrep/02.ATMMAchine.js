function solve(matrix) {
    let totalCashInATM = [];
    matrix.forEach(command => {
        if (command.length > 2) {
            totalCashInATM.push(...command);
            console.log(`Service Report: ${sumOfBanknots(command)}$ inserted. Current balance: ${sumOfBanknots(totalCashInATM)}$.`);
        } else if (command.length === 2) {
            let currentBalance = command[0];
            let moneyToWithdraw = command[1];
            if (currentBalance < moneyToWithdraw) {
                console.log(`Not enough money in your account. Account balance: ${currentBalance}$.`);
            } else if (moneyToWithdraw > sumOfBanknots(totalCashInATM)) {
                console.log('ATM machine is out of order!');
            } else {
                let sum = 0;
                totalCashInATM = totalCashInATM.sort((a, b) => b-a);
                for (let i = 0; i < totalCashInATM.length; i++) {
                    if (sum === moneyToWithdraw) {
                        break;
                    } 

                    if (sum + totalCashInATM[i] <= moneyToWithdraw) {
                        sum += +(totalCashInATM.splice(i, 1));
                        i--;
                    }
                }
                console.log(`You get ${sum}$. Account balance: ${currentBalance - sum}$. Thank you!`)
            }
        } else if (command.length === 1){
            let bankonteToFind = command[0];
            console.log(countOfBanknots(totalCashInATM, bankonteToFind));
        }
    }
    );
        

    function sumOfBanknots(array) {
        return array.reduce((a, b) => a + b, 0);
    }

    function countOfBanknots(array, banknote) {
        let count = array.filter((b) => b === banknote).length;
        return `Service Report: Banknotes from ${banknote}$: ${count}.`;
    }
}

solve([[20, 5, 100, 20, 1],
    [457, 25],
    [1],
    [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
    [20, 85],
    [5000, 4500],
   ]
   )