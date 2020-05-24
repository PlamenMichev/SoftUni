function attachEvents() {
    const sendBtn = document.querySelector('#submit');
    const refreshBtn = document.querySelector('#refresh');
    const nameElement = document.querySelector('#author');
    const messageElement = document.querySelector('#content');
    const textAreaElement = document.querySelector('#messages');
    const url = 'https://rest-messanger.firebaseio.com/messanger.json';

    sendBtn.addEventListener('click', () => {
        const name = nameElement.value;
        const message = messageElement.value;

        fetch(url, {
            method: 'post',
            body: JSON.stringify({
                'author': `${name}`,
                'content': `${message}`
            })
        });

        messageElement.value = '';
        nameElement.value = '';
    });

    refreshBtn.addEventListener('click', () => {
        fetch(url)
        .then((response) => response.json())
        .then((data) => getMessages(data));
    });

    function getMessages(messages) {
        textAreaElement.innerHTML = '';
        Object.keys(messages).forEach(key => {
            textAreaElement.innerHTML += `${messages[key].author}: ${messages[key].content}\n`;
        });
    }
}

attachEvents();