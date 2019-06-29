function addItem() {
    let newNameElement = document.getElementById('newItemText');
    let listElement = document.getElementById('items');
    let newElement = document.createElement('li');
    newElement.innerHTML = newNameElement.value;
    listElement.appendChild(newElement);
    newNameElement.value = '';
}