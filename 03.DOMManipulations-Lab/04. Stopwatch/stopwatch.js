function stopwatch() {
    let startButton = document.getElementById('startBtn');
    let stopButton = document.getElementById('stopBtn');
    let clock = document.getElementById('time');
    let secondsElement = clock.textContent.split(':')[1];
    let minutesElement = clock.textContent.split(':')[0];
    minutesElement = '0';
    secondsElement = '0';
    let seconds = 0;
    let stop = false;

    startButton.addEventListener('click', () => {
        clock.textContent = '00:00';
        stopButton.disabled = false;
        startButton.disabled = true;
        let interval = setInterval(setSeconds, 1000);
        stopButton.addEventListener('click', () => {
            stopButton.disabled = true;
            startButton.disabled = false;
            clearInterval(interval);
        });
    });

    function setSeconds() {
        seconds++;
        secondsElement = seconds;
        if (secondsElement > 59) {
            minutesElement++;
            secondsElement = 0;
            seconds = 0;
        }

        clock.textContent = ((minutesElement <= 9) ? '0' + minutesElement : minutesElement) + ':'
         + ((secondsElement <= 9) ? '0' + secondsElement : secondsElement);
        console.log(seconds);
    }
}