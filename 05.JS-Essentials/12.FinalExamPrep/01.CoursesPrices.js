function solve(fundamentals, advanced, applications, formOfEducation) {
    let totalPrice = 0;
    if (fundamentals === true) {
        totalPrice += 170;
    }

    if (advanced === true) {
        totalPrice += 180;        
    }

    if (applications === true) {
        totalPrice += 190;        
    }

    if (fundamentals && advanced) {
        totalPrice -= 0.1 * 180;
    }

    if (fundamentals && advanced && applications) {
        totalPrice -= 0.06 * totalPrice;
    }

    if (formOfEducation === 'online') {
        totalPrice -= 0.06 * totalPrice;
    }

    console.log(Math.round(totalPrice));
}

solve(true, true, false, "onsite")