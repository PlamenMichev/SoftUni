function solve() {
    let sudokoMatrix = [[], [], []];
    let quickCheckButtonElement = document.getElementsByTagName('button')[0];
    let clearButtonElement = document.getElementsByTagName('button')[1];
    let sudokoElement = document.getElementsByTagName('tbody')[0];
    let rowsElements = Array.from(sudokoElement.children);
    let paragraphElement = document.querySelector('#check p');
    let tableElement = document.getElementsByTagName('table')[0];
    let hasWin = true;

    quickCheckButtonElement.addEventListener('click', () => {
        for (let i = 0; i < rowsElements.length; i++) {
            const element = rowsElements[i].children;

            for (let j = 0; j < rowsElements.length; j++) {
                let numberElement = element[j].children[0];
                sudokoMatrix[i][j] = Number(numberElement.value);
            }
            
        }

        for (let i = 0; i < sudokoMatrix.length; i++) {
            const element = sudokoMatrix[i];
            let currentArr = [];
            for (let j = 0; j < sudokoMatrix.length; j++) {
                const number = sudokoMatrix[i][j];
                if (currentArr.includes(number)) {
                    hasWin = false;
                    break;
                }
                currentArr.push(number);
            }

            if (hasWin == false) {
                paragraphElement.textContent = "NOP! You are not done yet...";
                paragraphElement.style.color = 'red';
                tableElement.style.border = "2px solid red";
                break;
            }
        }

        if (hasWin) {
            for (let i = 0; i < sudokoMatrix.length; i++) {
                const element = sudokoMatrix[i];
                let currentArr = [];
                for (let j = 0; j < 3; j++) {
                        const number = sudokoMatrix[2 - j][i];
                        console.log(number);

                        if (currentArr.includes(number)) {
                            hasWin = false;
                            break;
                        }
                        currentArr.push(number);
                }
    
                if (hasWin == false) {
                    paragraphElement.textContent = "NOP! You are not done yet...";
                    paragraphElement.style.color = 'red';
                    tableElement.style.border = "2px solid red";
                    break;
                }
            }
        }

        if (hasWin) {
                paragraphElement.textContent = "You solve it! Congratulations!";
                    paragraphElement.style.color = 'green';
                    tableElement.style.border = "2px solid green";
        }
    })
    
    clearButtonElement.addEventListener('click', () => {
        let inputElements = Array.from(document.getElementsByTagName('input'));
                    paragraphElement.textContent = '';
                    paragraphElement.style.color = '';
                    tableElement.style.border = 'none';
        for (let element of inputElements) {
            element.value = '';
        }
    })
}