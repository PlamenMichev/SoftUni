const helper = function () {

    const handler = function (response) {

        if (response.status >= 400) {
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const passwordCheck = function (params) {
        return params.password === params.rePassword;
    };

    const isLogged = function(context) {
        const loggedIn = storage.getData('userInfo') !== null;
        
        if(loggedIn){
            context.loggedIn = loggedIn;
            context.names = JSON.parse(storage.getData('userInfo')).firstName + ' ' + JSON.parse(storage.getData('userInfo')).lastName;
        }
    }

    return {
        handler,
        passwordCheck,
        isLogged,
    }
}();