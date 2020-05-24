(async function () {
    const displayElement = document.querySelector('#contacts');
    const { getTemplateFunc, registerPartial } = window.templates;
    await registerPartial('card', 'card');

    const cardsListFunc = await getTemplateFunc('cards-list');

    const contactsList = cardsListFunc({ contacts });
    displayElement.innerHTML = contactsList;

    const getParentCard = (element) => {
        const className = 'contact';
        let node = element.parentNode;
        while (node != null) {
            if (node.classList.contains(className)) {
                return node;
            }

            node = node.parentNode;
        }

        return node;
    }

    const handleDetails = (ev) => {
        const target = ev.target;
        const card = getParentCard(target);
        const details = card.querySelector('.details');
        details.style.display = details.style.display
            ? ''
            : 'none';
    }

    displayElement.addEventListener('click', ({ target }) => {

        if (target.classList.contains('detailsBtn')) {
            handleDetails({ target })
        }
    });
}());