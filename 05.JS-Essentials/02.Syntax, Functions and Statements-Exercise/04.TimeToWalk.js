function calculateTime(steps, footLength, speed) {
    let distanceInM = steps * footLength;
    let distanceInKm = distanceInM / 1000;
    let minutesRest = parseInt(distanceInM / 500);

    let totalSeconds = (distanceInKm / speed) * 3600 + (minutesRest *  60);
    let hours = parseInt(totalSeconds / 3600);
    totalSeconds -= hours * 3600;
    let minutes = parseInt(totalSeconds / 60);
    let seconds = totalSeconds % 60;
    
    let result = '';
    if (hours < 10) {
        result += `0${hours}:`;
    } else {
        result += hours + ':';
    }

    if(minutes < 10) {
        result += `0${minutes}:`;
    } else {
        result += minutes + ':';
    }

    if(seconds < 10) {
        result += `0${seconds.toFixed(0)}`;
    } else {
        result += seconds.toFixed(0);
    }
    console.log(result);
}

calculateTime(2564, 0.70, 5.5);