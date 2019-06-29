function encodeAndDecodeMessages() {
    let areaToSendElement = document.getElementsByTagName('textarea')[0];
    let areaToReciveElement = document.getElementsByTagName('textarea')[1];
    let encodeButton = document.getElementsByTagName('button')[0];
    let decodeButton = document.getElementsByTagName('button')[1];

    encodeButton.addEventListener('click', () => {
        let text = areaToSendElement.value;
        let textToSend = '';
        for (let letter of text) {
            textToSend += String.fromCharCode(letter.charCodeAt(0) + 1);
        }
        areaToReciveElement.value = textToSend;
        areaToSendElement.value = '';
    });

    decodeButton.addEventListener('click', () => {
        let text = areaToReciveElement.value;
        let textToSend = '';
        for (let letter of text) {
            textToSend += String.fromCharCode(letter.charCodeAt(0) - 1);
        }
        areaToReciveElement.value = textToSend;
    });
}