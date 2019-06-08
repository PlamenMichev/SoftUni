function solve(params) {
    let avaiablePlaces = +params[0];
    let levskiSeats = [];
    let litexSeats = [];
    let vipSeats = [];
    let collectedMoney = 0;
    let fansCount = 0;

    for (let place of params.splice(1)) {
        let currentSeat = place.split('*');
        let team = currentSeat[0];
        let seat = +currentSeat[1];
        let sector = currentSeat[2];
        let isAvaiable = false;
        let fullSeat = seat + ' ' + sector;
        if (team == 'LITEX') {
            if ((seat < 0 || seat > avaiablePlaces) ||  litexSeats.includes(fullSeat)) {
                console.log(`Seat ${seat} in zone ${team} sector ${sector} is unavailable`)
            } else {
                litexSeats.push(seat + ' ' + sector);
                isAvaiable = true;
            }
        } else if (team == 'LEVSKI') {
            if ((seat < 0 || seat > avaiablePlaces) ||  levskiSeats.includes(fullSeat)) {
                console.log(`Seat ${seat} in zone ${team} sector ${sector} is unavailable`)
            } else {
                levskiSeats.push(seat + ' ' + sector);
                isAvaiable = true;
            }
        } else {
            if ((seat < 0 || seat > avaiablePlaces) ||  vipSeats.includes(fullSeat)) {
                console.log(`Seat ${seat} in zone ${team} sector ${sector} is unavailable`)
            } else {
                vipSeats.push(seat + ' ' + sector);
                isAvaiable = true;
            }
        }

        if (isAvaiable === true) {
            fansCount++;
            if (sector == 'A') {
                if (team == 'VIP') {
                     collectedMoney += 25;
                } else {
                    collectedMoney += 10;
                }
            } else if (sector == 'B') {
                if (team == 'VIP') {
                    collectedMoney += 15;                     
                } else {
                    collectedMoney += 7;                    
                }
            } else if (sector == 'C') {
                if (team == 'VIP') {
                    collectedMoney += 10;
                } else {
                    collectedMoney += 5;                    
                }
            }
        }
    }

    console.log(`${collectedMoney} lv.`);
    console.log(`${fansCount} fans`);
}


solve(
["5","LITEX*5*A", "LEVSKI*2*A", "LEVSKI*3*B", "VIP*4*C", "LITEX*3*B", "LEVSKI*2*A", "LITEX*5*B", "LITEX*5*A", "VIP*1*A"]
)