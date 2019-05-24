function solve() {
    let expressionOutputElement = document.getElementById('expressionOutput');
    let resultOutputElement = document.getElementById('resultOutput');
    let buttons = Array.from(document.getElementsByTagName('button'));
    let exp = '';
    let operants = ['/', '*', '-', '+'];

    for (let i = 0; i < buttons.length; i++) {
        const element = buttons[i];
        element.addEventListener('click', () => {
            if (operants.includes(element.value)) {
                exp += ' ' + element.value + ' ';
                expressionOutputElement.textContent += ' ' + element.value + ' ';
            } else if (element.value == '='){
                if (exp.trim().split(' ').length == 3) {
                    let firstNum = exp.split(' ')[0];
                    let secNum = exp.split(' ')[2];
                    let operant = exp.split(' ')[1];
                    
                    resultOutputElement.textContent += eval(`${firstNum} ${operant} ${secNum}`);
                } else {
                    resultOutputElement.textContent = 'NaN';
                }

                exp = '';
            } else if (element.value == 'Clear') {
                expressionOutputElement.textContent = '';
                resultOutputElement.textContent = '';
            } else {
                exp += element.value;
                expressionOutputElement.textContent += element.value;
            }
        })
    }
}