function addItem() {
    let newNameElement = document.getElementById('newText');
    let listElement = document.getElementById('items');
    let newElement = document.createElement('li');
    newElement.innerHTML = newNameElement.value;
    listElement.appendChild(newElement);
    newNameElement.value = '';
    let deleteButtonElement = document.createElement('a');
    deleteButtonElement.innerHTML = ' <a href=#>[Delete]</a>';
    newElement.appendChild(deleteButtonElement);
    deleteButtonElement.addEventListener('click', function() {
        this.parentNode.remove();
    });
}