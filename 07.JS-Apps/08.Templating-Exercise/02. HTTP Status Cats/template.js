(() => {
    const elements = {
        sectionToShow: document.querySelector('#allCats ul'),
    }
    renderCatTemplate();

    async function renderCatTemplate() {
        const handleClick = function () {
            const currentElement = this.parentNode;
            const detailsElement = currentElement.querySelector('.status');
            detailsElement.style.display = detailsElement.style.display === 'none'
                ? detailsElement.style.display = 'block'
                : detailsElement.style.display = 'none';
        }

        const { cats } = window;
        const template = document.getElementById('cat-template').innerHTML;
        const templateFunc = Handlebars.compile(template);
        const fragment = document.createDocumentFragment();
        fragment.innerHTML = '';
        for (const cat of cats) {
            cat.imageLocation = `./images/${cat.imageLocation}.jpg`;
            fragment.innerHTML += templateFunc(cat);
        }

        elements.sectionToShow.innerHTML = fragment.innerHTML;

        const buttons = elements.sectionToShow.querySelectorAll('button');
        for (const button of buttons) {
            button.addEventListener('click', handleClick);
        }
    }

})();
