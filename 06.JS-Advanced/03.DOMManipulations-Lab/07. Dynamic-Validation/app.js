function validate() {
    let emailField = document.getElementById('email');
    let lastCondition = 'correct';
    let regex = /[a-z]+@[a-z]+.[a-z]+/g;

    emailField.addEventListener('change', () => {
        let currentCondition = '';
        if (emailField.value.match(regex) != null) {
            emailField.classList.remove('error');   
            currentCondition = 'correct';
        } else {
            currentCondition = 'error'
        }

        if (currentCondition != lastCondition) {
            if (currentCondition === 'error') {
                emailField.classList.add('error');   
            }
        }

        lastCondition = currentCondition;
    });
}