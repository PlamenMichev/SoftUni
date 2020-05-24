const helper = function() {

    const validatePassword = function() {
        //TODO:
    }

    const handler = function(response) {
        if (response.status >= 400) {
            if (response.status === 401) {   
                throw Error('You dont have an account');
            }

            throw Error(response.statusText);
        }
    }

    const validateUsername = function(username) {
        if (username.length < 3) {
            throw Error('Username has to be at least 3 symbols!');
        }
    }

    const handleError = function(errorMessage) {
        const element = document.querySelector('#errorBox');
        element.innerHTML = errorMessage;
        element.style.display = 'block';
        element.addEventListener('click', () => { 
            element.style.display = 'none';
        });
        setTimeout(function() { 
            element.style.display = 'none';
        }, 5000);
    }

    const showSuccess = function(message) {
        const element = document.querySelector('#successBox');
        element.innerHTML = message;
        element.style.display = 'block';
        element.addEventListener('click', () => { 
            element.style.display = 'none';
        });
        
        setTimeout(function() { 
            element.style.display = 'none';
        }, 5000);
    }

    const showLoading = function() {
        const element = document.querySelector('#loadingBox');
        element.style.display = 'block';
    }

    const removeLoading = function() {
        const element = document.querySelector('#loadingBox');
        element.style.display = 'none';
    }

    return {
        validatePassword,
        validateUsername,
        handleError,
        handler,
        showSuccess,
        showLoading,
        removeLoading,
    }
}();