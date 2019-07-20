function solve() {
    let currentId = 'depot';
    const stopNameElement = document.querySelector('#info .info');
    const departButton = document.querySelector('#depart');
    const arriveButton = document.querySelector('#arrive');
    let currentStopName = '';

    function depart() {
        departButton.disabled = true;
        arriveButton.disabled = false;
        const url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;
        fetch(url)
        .then((response) => response.json())
        .then((data) => updateInfo(data))
        .catch(() => showError())
    }

    function arrive() {
        departButton.disabled = false;
        arriveButton.disabled = true;
        stopNameElement.innerHTML = `Arriving at ${currentStopName}`;
    }

    function updateInfo(stops) {
        const { name, next } = stops;
        stopNameElement.innerHTML = `Next stop ${name}`;
        currentId = next;
        currentStopName = name;
    }

    function showError() {
        stopNameElement.innerHTML = 'Error';
        departButton.disabled = true;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();