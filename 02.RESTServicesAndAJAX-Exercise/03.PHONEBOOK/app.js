function attachEvents() {
    const getUrl = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    const list = document.getElementById('phonebook');
    const loadButton = document.getElementById('btnLoad');
    const nameElement = document.querySelector('#person');
    const phoneElement = document.querySelector('#phone');
    const createButton = document.querySelector('#btnCreate');
    let deleteBtns = [];

    createButton.addEventListener('click', () => {
        const name = nameElement.value;
        const phone = phoneElement.value;
        nameElement.value = '';
        phoneElement.value = '';
        const postUrl = getUrl;

        fetch(postUrl, {
            method: 'post',
            body: JSON.stringify({
                "person": `${name}`,
                "phone": `${phone}`
            }
            )
        }).then(() => {
            fetch(getUrl)
            .then((response) => response.json())
            .then((data) => getEntries(data))
            .then(() => addListenersOnDltButtons())
            .catch(() => showError());
        });
    });

    loadButton.addEventListener('click', () => {
        fetch(getUrl)
            .then((response) => response.json())
            .then((data) => getEntries(data))
            .then(() => addListenersOnDltButtons())
            .catch(() => showError());

    });

    function addListenersOnDltButtons() {

        for (let i = 0; i < deleteBtns.length; i++) {
            const btn = deleteBtns[i];
            btn.addEventListener('click', () => {
                let currentKey = '';
                fetch(getUrl)
                    .then((response) => response.json())
                    .then((data) => {
                        const keys = Object.keys(data);
                        currentKey = keys[i];
                    })
                    .then(() => {
                        let dltUrl = `https://phonebook-nakov.firebaseio.com/phonebook/${currentKey}.json`;
                        fetch(dltUrl,
                            {
                                method: 'delete'
                            })
                            .then(() => {
                                fetch(getUrl)
                                    .then((response) => response.json())
                                    .then((data) => getEntries(data))
                                    .then(() => addListenersOnDltButtons())
                                    .catch(() => showError());
                            });
                    });

            });
        }
    }

    function getEntries(entries) {
        const keys = Object.keys(entries);
        deleteBtns = [];
        list.textContent = '';
        keys.map((key) => {
            const liElement = document.createElement('li');
            const deleteBtn = document.createElement('button')
            deleteBtns.push(deleteBtn);
            const name = entries[key].person;
            const number = entries[key].phone;
            deleteBtn.textContent = 'Delete';
            liElement.textContent = `${name}:${number} `;
            liElement.appendChild(deleteBtn);
            list.appendChild(liElement);
        });
    }

    function showError() {
        list.textContent = 'There is no entities to show!';
    }
}

attachEvents();