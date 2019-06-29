function toggle() {
    let button = document.querySelector('.button');
    let extendedDiv = document.getElementById('extra');
    if (extendedDiv.style.display !== 'block') {
        extendedDiv.style.display = 'block';
        button.innerHTML = 'Less';
    } else  {
        extendedDiv.style.display = 'none';
        button.innerHTML = 'More';
    }
}

