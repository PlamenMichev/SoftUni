function attachEventsListeners() {
    let allToDays = {
        0: 1,
        1: 24,
        2: 1440,
        3: 86400,
    };

    let elements = Array.from(document.querySelectorAll('input')).filter(x => x.type === 'button');
    let inputElements = Array.from(document.querySelectorAll('input')).filter(x => x.type !== 'button');
    console.log(inputElements)

    for (let i = 0; i < elements.length; i++) {
        const element = elements[i];
        element.addEventListener('click', () => {
            let num = inputElements[i].value;

            for (let j = 0; j < inputElements.length; j++) {
                let input = inputElements[j];
                let inDays = num/allToDays[i];
                console.log(inDays);
                input.value = inDays * allToDays[j];
            }
        });
    }

}