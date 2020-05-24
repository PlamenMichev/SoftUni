function findSameNumbers(num) {
    let numAsString = `${num}`;
    let previousElement = numAsString[0];
    let areSame = true;
    let sum = Number(previousElement);
    for (let i = 1; i < numAsString.length; i++) {
        const element = numAsString[i];
        if (element != previousElement) {
            areSame = false;
        }

        previousElement = element;
        sum += Number(element);
    }

    console.log(`${areSame}`);
    console.log(sum);
}

findSameNumbers(1234);