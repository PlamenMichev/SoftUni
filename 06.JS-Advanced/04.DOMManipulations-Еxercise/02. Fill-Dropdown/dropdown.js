function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let dropdownMenuElement = document.getElementById('menu');
    let newOption = document.createElement('option');
    newOption.innerHTML = `${textElement.value} ${valueElement.value}`;
    dropdownMenuElement.appendChild(newOption);

    textElement.value = '';
    valueElement.value = '';
}