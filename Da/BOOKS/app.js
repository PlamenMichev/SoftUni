const elements = {
    loadBtn: document.querySelector('#loadBooks'),
    tableBody: document.querySelector('table tbody'),
    addBtn: document.querySelector('form button'),
    titleElement: document.querySelectorAll('form input')[0],
    isbnElement: document.querySelectorAll('form input')[2],
    authorElement: document.querySelectorAll('form input')[1],
    titleUpd: document.querySelectorAll('#update input')[0],
    authorUpd: document.querySelectorAll('#update input')[1],
    isbnUpd: document.querySelectorAll('#update input')[2],
    updBtn: document.querySelector('#update button'),
    tdElementPattern: document.querySelector('#initialTd'),
}

const appId = 'kid_SyHI0W7zB';
const appSecret = 'cd4eb978002d49b1912edda64cbc33c6';
const base64NameAndPass = 'Z3Vlc3Q6Z3Vlc3Q=';

const listAllBooks = function listAllBooks() {
    const url = `https://baas.kinvey.com/appdata/${appId}/books`;
    elements.tableBody.innerHTML = '';
    fetch(url, {
        headers: {
            'content-type': 'application/json',
            'authorization': `Basic ${base64NameAndPass}`,
        },
    })
        .then((response) => {
            if (response.status >= 400) {
                throw Error('Something went wrong!');
            }

            return response.json();
        }
        )
        .then((data) => {
            const keys = Object.keys(data);
            if (keys.length === 0) {
                throw Error('No books to show!');
            }
            keys.forEach((key) => {
                const name = data[key].title;
                const author = data[key].author;
                const isbn = data[key].isbn;
                const trElement = elements.tdElementPattern.cloneNode(true);
                trElement.id = data[key]._id;
                trElement.querySelectorAll('td')[0].innerHTML = name;
                trElement.querySelectorAll('td')[1].innerHTML = author
                trElement.querySelectorAll('td')[2].innerHTML = isbn;

                const dltBtn = trElement.querySelectorAll('button')[1];
                const updBtn = trElement.querySelectorAll('button')[0];
                dltBtn.addEventListener('click', deleteItem);
                updBtn.addEventListener('click', updateElement);
                trElement.style.display = 'block';
                trElement.style.display = 'table-row';
                elements.tableBody.appendChild(trElement);
            });
        })
        .catch((err) => {
            elements.tableBody.innerHTML = err.message;
        });
};

const addBook = function addBook(ev) {
    ev.preventDefault();
    elements.addBtn.disabled = true;
    elements.loadBtn.disabled = true;
    const url = `https://baas.kinvey.com/appdata/${appId}/books`;
    try {
        if (elements.titleElement.value === '' ||
            elements.authorElement.value === '' ||
            elements.isbnElement.value === '') {
            throw new Error('All data is required! Reload the books again in order to see them!');
        }

        fetch(url, {
            method: 'post',
            headers: {
                'content-type': 'application/json',
                'authorization': `Basic ${base64NameAndPass}`
            },
            body: JSON.stringify({
                title: elements.titleElement.value,
                author: elements.authorElement.value,
                isbn: elements.isbnElement.value,
            })
        })
            .then(() => {
                //Adding just one element
                const name = elements.titleElement.value;
                const author = elements.authorElement.value;
                const isbn = elements.isbnElement.value;

                elements.titleElement.value = '';
                elements.authorElement.value = '';
                elements.isbnElement.value = '';

                const trElement = elements.tdElementPattern.cloneNode(true);
                trElement.id = elements._id;
                trElement.querySelectorAll('td')[0].innerHTML = name;
                trElement.querySelectorAll('td')[1].innerHTML = author
                trElement.querySelectorAll('td')[2].innerHTML = isbn;

                const dltBtn = trElement.querySelectorAll('button')[1];
                const updBtn = trElement.querySelectorAll('button')[0];
                dltBtn.addEventListener('click', deleteItem);
                updBtn.addEventListener('click', updateElement);
                trElement.style.display = 'block';
                trElement.style.display = 'table-row';
                elements.tableBody.appendChild(trElement);
            })
            .then(() => {
                elements.addBtn.disabled = false;
                elements.loadBtn.disabled = false;
            })
            .catch((err) => {
                elements.tableBody.innerHTML = err.message;
            });
    } catch (err) {
        elements.tableBody.innerHTML = err.message;
    }
};

const deleteItem = function deleteItem() {
    const trElement = this.parentElement.parentElement;
    const id = trElement.id;
    const url = `https://baas.kinvey.com/appdata/${appId}/books/${id}`;
    fetch(url, {
        method: 'delete',
        headers: {
            'content-type': 'application/json',
            'authorization': `Basic ${base64NameAndPass}`
        }
    });

    trElement.remove();
}

const updateElement = function updateElement() {
    elements.addBtn.disabled = true;
    elements.loadBtn.disabled = true;

    document.querySelector('#update').style.display = 'block';
    const trElement = this.parentElement.parentElement;
    elements.titleUpd.value = trElement.querySelectorAll('td')[0].innerHTML;
    elements.authorUpd.value = trElement.querySelectorAll('td')[1].innerHTML;
    elements.isbnUpd.value = trElement.querySelectorAll('td')[2].innerHTML;
    const id = trElement.id;
    const url = `https://baas.kinvey.com/appdata/${appId}/books/${id}`;

    elements.updBtn.addEventListener('click', (ev) => {
        ev.preventDefault();
        try {
            if (elements.titleUpd.value === '' ||
                elements.authorUpd.value === '' ||
                elements.isbnUpd.value === '') {
                throw new Error('All data is required! Reload the books again in order to see them!');
            }

            fetch(url, {
                method: 'put',
                headers: {
                    'content-type': 'application/json',
                    'authorization': `Basic ${base64NameAndPass}`
                },
                body: JSON.stringify({
                    title: elements.titleUpd.value,
                    author: elements.authorUpd.value,
                    isbn: elements.isbnUpd.value,
                })
            })
                .then(() => {
                    listAllBooks();
                    elements.titleUpd.value = '';
                    elements.authorUpd.value = '';
                    elements.isbnUpd.value = '';
                })
                .then(() => {
                    elements.addBtn.disabled = false;
                    elements.loadBtn.disabled = false;
                    elements.updBtn.disabled = false;
                })
                .then(() => {
                    document.querySelector('#update').style.display = 'none';
                })
                .catch((err) => {
                    elements.tableBody.innerHTML = err.message;
                });
        } catch (err) {
            elements.tableBody.innerHTML = err.message;
        }
    });
}

elements.loadBtn.addEventListener('click', listAllBooks);
elements.addBtn.addEventListener('click', addBook);