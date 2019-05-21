function validPoints(input) {
    let x1 = input[0];
    let y1 = input[1];
    let x2 = input[2];
    let y2 = input[3];

    let distanceFromPoint1ToStart = Math.sqrt(x1 ** 2 + y1 ** 2);
    let distanceFromPoint2ToStart = Math.sqrt(x2 ** 2 + y2 ** 2);
    let distanceBetweenPoints = Math.sqrt((x1 - x2) ** 2 + (y2 - y1) ** 2)

    if (parseInt(distanceFromPoint1ToStart) == distanceFromPoint1ToStart) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (parseInt(distanceFromPoint2ToStart) == distanceFromPoint2ToStart) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (parseInt(distanceBetweenPoints) == distanceBetweenPoints) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

validPoints([2, 1, 1, 1]);