function attachGradientEvents() {
    let divElement = document.getElementById('gradient');
    let result = document.getElementById('result');
    divElement.addEventListener('mousemove', (event) => {
        let position = event.offsetX;
        let divLength = divElement.clientWidth;
        let percentage = Math.trunc((position * 100) / divLength);
        result.textContent = `${percentage}%`;
    });

    divElement.addEventListener('mouseout', (event) => {
        result.textContent = ``;
    });
}