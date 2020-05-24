function subtract() {
    let firstNum = +document.getElementById('firstNumber').value;
    let secNum = +document.getElementById('secondNumber').value;
    let resultBox = document.getElementById('result');

    resultBox.innerHTML = firstNum - secNum;
}