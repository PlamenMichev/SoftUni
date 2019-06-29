function lockedProfile() {
    let buttons = Array.from(document.querySelectorAll('button'));
    let profiles = Array.from(document.querySelectorAll('.profile'));
    for (let i = 0; i < buttons.length; i++) {
        const button = buttons[i];
        button.addEventListener('click', function () {
            let inputs = Array.from(profiles[i].querySelectorAll('input'));
            let isLock = inputs[0].checked;
            if (!isLock) {
                let divToShow = document.getElementById(`user${i+1}HiddenFields`);
                if (divToShow.style.display !== 'block') {
                    divToShow.style.display = 'block';
                    buttons[i].innerHTML = 'Hide it';
                } else {
                    divToShow.style.display = 'none';
                    buttons[i].innerHTML = 'Show more';
                }
            }
        });
    }
}