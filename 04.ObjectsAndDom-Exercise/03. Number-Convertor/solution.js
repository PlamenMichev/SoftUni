function solve() {
    let buttonElement = document.querySelector('#container button');
    let menuElement = document.getElementById('selectMenuTo');

    let firstOptionElement = document.querySelector('#selectMenuTo option');
    console.log(firstOptionElement);
    firstOptionElement.value = 'binary';
    firstOptionElement.textContent = 'Binary';

    let secOption = document.createElement('option');
    secOption.value = 'hexadecimal';
    secOption.textContent = 'Hexadecimal';
    
    menuElement.appendChild(firstOptionElement);
    menuElement.appendChild(secOption);

    buttonElement.addEventListener('click', () => {
        let numberElement = document.getElementById('input');
        let number = numberElement.value;
        let chooseBoxElement = document.getElementById('selectMenuTo');
        let resultBoxElement = document.getElementById('result');
        let choice = chooseBoxElement.value;
        if (choice == 'binary') {
            var bin = (+number).toString(2);
            resultBoxElement.value = bin;
        } else {
            var bin = (+number).toString(16);
            resultBoxElement.value = bin.toUpperCase();
        }
    })
}