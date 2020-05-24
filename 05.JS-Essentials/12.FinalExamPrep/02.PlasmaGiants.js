function solve(plasmaArray, num) {
    let firstGiant = plasmaArray.slice(0, plasmaArray.length / 2);
    let secGiant = plasmaArray.slice(plasmaArray.length / 2);
    let dmg = Math.min(...plasmaArray);
    let max = Math.max(...plasmaArray);

    let firstGiantArrays = [];
    let secGiantArrays = [];
    let length = firstGiant.length / num;

    for (let i = 0; i < plasmaArray.length / 2; i += num) {
        firstGiantArrays.push(firstGiant.splice(0, num));
        secGiantArrays.push(secGiant.splice(0, num));

    }

    // for (let i = 0; i < length; i++) {
    //     let currentArray = [];
    //     let secArray = [];
    //     for (let j = 0; j < num; j++) {
    //         currentArray.push(firstGiant.shift());
    //         secArray.push(secGiant.shift());
    //     }
        
    //     firstGiantArrays.push(currentArray);
    //     secGiantArrays.push(secArray);
    // }

    let firstGiantHealth = 0;
    let secGianteHealth = 0;
    for (let arr of firstGiantArrays) {
        let sum = 1;
        for (let i = 0; i < arr.length; i++) {
            const number = arr[i];
            sum *= number;
        }

        firstGiantHealth += sum;
    }

    for (let arr of secGiantArrays) {
        let sum = 1;
        for (let i = 0; i < arr.length; i++) {
            const number = arr[i];
            sum *= number;
        }

        secGianteHealth += sum;
    }
    
    let rounds = 1;
    while (firstGiantHealth > max && secGianteHealth > max && dmg !== 0) {
        firstGiantHealth -= dmg;
        secGianteHealth -= dmg;
        rounds++;
    }
    
    if (firstGiantHealth === secGianteHealth) {
        console.log(`Its a draw ${firstGiantHealth} - ${secGianteHealth}`);
        return;
    }

    if (firstGiantHealth < secGianteHealth) {
        console.log(`Second Giant defeated First Giant with result ${secGianteHealth} - ${firstGiantHealth} in ${rounds} rounds`)
        return;
    } else {
        console.log(`First Giant defeated Second Giant with result ${firstGiantHealth} - ${secGianteHealth} in ${rounds} rounds`)
        return;
    }
}

solve([4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 4, 4], 0) 