function checkSpeed(input) {
    let place = input[1];
    let speed = input[0];
    switch (place) {
        case 'city':{
            if (speed - 50 <= 0) {
                break;
            }
            if (speed - 50 <= 20) {
                console.log('speeding');
            } else if (speed - 50 <= 40) {
                console.log('excessive speeding');
            } else {
                console.log('reckless driving ');
            }
            break;
        }
        case 'motorway':{
            if (speed - 130 <= 0) {
                break;
            }
            if (speed - 130 <= 20) {
                console.log('speeding');
            } else if (speed - 130 <= 40) {
                console.log('excessive speeding');
            } else {
                console.log('reckless driving ');
            }
            break;
        }
        case 'interstate':{
            if (speed - 90 <= 0) {
                break;
            }
            if (speed - 90 <= 20) {
                console.log('speeding');
            } else if (speed - 90 <= 40) {
                console.log('excessive speeding');
            } else {
                console.log('reckless driving ');
            }
            break;
        }
        case 'residential':{
            if (speed - 20 <= 0) {
                break;
            }
            if (speed - 20 <= 20) {
                console.log('speeding');
            } else if (speed - 20 <= 40) {
                console.log('excessive speeding');
            } else {
                console.log('reckless driving ');
            }
            break;
        }
    }
}

checkSpeed([200, 'motorway']);