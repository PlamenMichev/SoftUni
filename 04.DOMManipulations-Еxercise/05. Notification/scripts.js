function notify(message) {
    let divElement = document.getElementById('notification');
    console.log(divElement);

    divElement.innerHTML = message;
    divElement.style.display = 'block';
    setTimeout(showMsg, 2000);


    function showMsg() {
        divElement.style.display = 'none';
    }
}