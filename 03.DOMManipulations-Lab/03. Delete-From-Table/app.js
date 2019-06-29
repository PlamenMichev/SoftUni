function deleteByEmail() {
    let emailToSearch = document.querySelector('input').value;
    let rows = document.querySelectorAll('table tbody tr');
    let resultElement = document.getElementById('result');
    for (let i = 0; i < rows.length; i++) {
        const row = rows[i];
        if(row.lastElementChild.textContent === emailToSearch) {
            row.remove();
            resultElement.innerHTML = 'Found.';
            return;
        }
    }

    resultElement.innerHTML = 'Not found.';
}