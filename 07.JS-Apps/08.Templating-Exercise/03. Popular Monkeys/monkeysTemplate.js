$(() => {
    const handleClick = function (id) {
        const elementToShow = document.getElementById(id);
        elementToShow.style.display = elementToShow.style.display === 'none'
            ? elementToShow.style.display = 'block'
            : elementToShow.style.display = 'none';
    }

    const templateText = document.querySelector('#monkey-template').innerHTML;
    const divToShow = document.querySelector('.monkeys');
    const templateFunc = Handlebars.compile(templateText);
    const fragment = document.createDocumentFragment();
    fragment.innerHTML = '';
    for (const monkey of monkeys) {
        const element = templateFunc(monkey);
        fragment.innerHTML += element;
    }

    divToShow.innerHTML = fragment.innerHTML;
    const buttons = divToShow.querySelectorAll('button');
    for (let i = 0; i < buttons.length; i++) {
        const button = buttons[i];
        button.addEventListener('click', (ev) => handleClick(i + 1, ev));
    }
});