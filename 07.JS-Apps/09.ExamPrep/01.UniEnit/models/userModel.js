const userModel = function() {

    const register = function(params) {
        const username = params.username;
        const password = params.password;
        const rePassword = params.rePassword;

        try {
            helper.validateUsername(username);
            const auth = btoa(`${storage.appKey}:${storage.appSecret}`);
            const headers = {
                headers: {
                    'authorization': `Basic ${auth}`,
                    'content-type': 'application/json',
                },

                body: JSON.stringify({
                    username: username,
                    password: password,
                }),
            }
            const url = `user/${storage.appKey}`;

            return requster.post(url, headers);
        } catch (error) {
            helper.handleError(error.message);
            userContoller.getRegister(params);
        }
    };

    const login = function(params) {
        const username = params.username;
        const password = params.password;
        const url = `user/${storage.appKey}/login`;
        const auth = btoa(`${username}:${password}`);
        const headers = {
            headers: {
                'authorization': `Basic ${auth}`,
                'content-type': 'application/json',
            },

            body: JSON.stringify({
                username: username,
                password: password,
            }),
        };
        
        return requster.post(url, headers);
    }

    const logout = function() {
        const authKey = JSON.parse(storage.getData('authKey'));
        const auth = `Kinvey ${authKey}`;
        const url = `user/${storage.appKey}/_logout`;
        const headers = {
            headers: {
                'authorization': auth
            },
        };

        return requster.post(url, headers);
    }

    const getUser = async function() {
        let currentUser = await requster.get(`user/${storage.appKey}/${JSON.parse(storage.getData('userInfo'))._id}`, {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        });

        currentUser = await currentUser.json();

        return currentUser;

    }

    const addEvents = function(url, currentUser, currentEvent) {
        const headers = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            },
            body: JSON.stringify({
                username: currentUser.username,
                events: [currentEvent.name],
            })
        }
        
        return requster.put(url, headers);
    }

    const addEvent = function(url, currentUser, currentEvent) {
        const events = currentUser.events;
        events.push(currentUser.name)
        const headers = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            },
            body: JSON.stringify({
                username: currentUser.username,
                events: [currentEvent.name],
            })
        }

        return requster.put(url, headers);
    }

    return {
        register,
        login,
        logout,
        getUser,
        addEvents,
        addEvent,
    }
}();