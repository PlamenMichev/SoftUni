function solve() {
    let inputBoxElement = document.getElementsByTagName('input')[0];
    let addButtonElement = document.getElementsByTagName('button')[0];
    let tableElements = document.getElementsByTagName('ol')[0];
    let rowElements = tableElements.children;
    
    addButtonElement.addEventListener('click', () => {
        let name = inputBoxElement.value.toLowerCase();
        let firstLetter = name[0];
        let firstLetterNumber = firstLetter.charCodeAt(0);
        let numberInAlphabet = Number(firstLetterNumber - 97);
        let currentElement = rowElements[numberInAlphabet];
        if (!currentElement.textContent) {
            currentElement.textContent += name.charAt(0).toUpperCase() + name.slice(1);
        } else {
            currentElement.textContent += ', ' + name.charAt(0).toUpperCase() + name.slice(1);
        }
        
        inputBoxElement.textContent = '';
    })
    
}

