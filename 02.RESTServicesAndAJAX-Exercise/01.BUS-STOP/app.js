function getInfo() {
    let stopId = document.getElementById('stopId');
    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json`;
    const stopNameElement = document.getElementById('stopName');
    const busList = document.getElementById('buses');

    fetch(url)
    .then((response) => response.json())
    .then((data) => takeBuses(data))
    .catch(() => showError())

    stopId.value = '';

    function takeBuses(busesInfo) {
        let { name, buses } = busesInfo;
        stopNameElement.textContent = name;
        Array.from(Object.keys(buses)).forEach(bus => {
            const busItem = document.createElement('li');
            busItem.textContent = `Bus ${bus} arrives in ${buses[bus]}`;
            busList.appendChild(busItem);
        });
    }

    function showError() {
        stopNameElement.textContent = 'Error';
        busList.innerHTML = '';
    }
}