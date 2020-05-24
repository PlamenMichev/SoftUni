const eventModel = function () {
    const getAllEvents = async function () {
        const url = `appdata/${storage.appKey}/events`;
        const auth = `Kinvey ${JSON.parse(storage.getData('authKey'))}`;
        const headers = {
            headers: {
                'authorization': auth,
                'content-type': 'application/json'
            },
        }

        const request = await requster.get(url, headers);
        const obj = await request.json();
        return obj;
    }

    const createEvent = function (params) {
        const dateTime = params.dateTime;
        const description = params.description;
        const name = params.name;
        const imageUrl = params.imageURL;
        const url = `appdata/${storage.appKey}/events`;

        const body = JSON.stringify({
            dateTime: dateTime,
            description: description,
            name: name,
            imageUrl: imageUrl,
            creator: JSON.parse(storage.getData('userInfo')).username,
            going: 1,
        });

        const headers = {
            body: body,
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        }

        return requster.post(url, headers);
    }

    const updateEvent = async function (params, id) {
        const dateTime = params.dateTime;
        const description = params.description;
        const name = params.name;
        const imageUrl = params.imageURL;
        const getHeaders = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        }
        const url = `appdata/${storage.appKey}/events/${id}`;
        let currentEvent = await requster.get(url, getHeaders);
        currentEvent = await currentEvent.json();

        const body = JSON.stringify({
            dateTime: dateTime,
            description: description,
            name: name,
            imageUrl: imageUrl,
            creator: currentEvent.creator,
            going: currentEvent.going,
        });

        const headers = {
            body: body,
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        }

        return requster.put(url, headers);
    }

    const updateGoing = function(params, id) {
        const upd = params.going + 1;

        const eventBody = JSON.stringify({
            dateTime: params.dateTime,
            description: params.description,
            name: params.name,
            imageUrl: params.imageUrl,
            creator: params.creator,
            going: upd,
        });

        const eventHeaders = {
            body: eventBody,
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        }
        
        return requster.put(`appdata/${storage.appKey}/events/${id}`, eventHeaders);
    }

    const getEvent = async function(id) {
        
        let currentEvent = await requster.get(`appdata/${storage.appKey}/events/${id}`, {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        });

        currentEvent = await currentEvent.json();

        return currentEvent;
    }

    return {
        getAllEvents,
        createEvent,
        updateEvent,
        updateGoing,
        getEvent
    }

}();