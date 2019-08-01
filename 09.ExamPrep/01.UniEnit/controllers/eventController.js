const eventController = function () {

    const getEvent = function (context) {
        context.isLogged = storage.getData('userInfo') || false;
        if (context.isLogged) {
            context.username = JSON.parse(storage.getData('userInfo')).username;
        }
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/event/organizeEventPage.hbs')
        });
    };

    const postEvent = function (context) {
        eventModel.createEvent(context.params)
            .then(r => {
                helper.handler(r);
                return r;
            })
            .then(async () => {
                helper.removeLoading();
                helper.showSuccess('Event created successfully.');
                eventController.getEvent(context);
            }).catch((err) => {
                helper.handleError(err.message);
                homeController.getHome(context);
            });
    }

    const getDetails = async function (context) {
        const id = context.params.id.slice(1);
        const headers = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        };

        const url = `appdata/${storage.appKey}/events/${id}`;
        let currentEvent = await requster.get(url, headers);
        currentEvent = await currentEvent.json();

        context.isLogged = storage.getData('userInfo') || false;
        if (context.isLogged) {
            context.username = JSON.parse(storage.getData('userInfo')).username;
        }
        context.img = currentEvent.imageUrl;
        context.name = currentEvent.name;
        context.description = currentEvent.description;
        context.date = currentEvent.dateTime;
        context.organizer = currentEvent.creator;
        context.interestedPeople = currentEvent.going;
        context.isCreator = currentEvent.creator == JSON.parse(storage.getData('userInfo')).username;
        context._id = id;
        
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/event/details.hbs')
        });
    }

    const getEdit = async function (context) {
        console.log(context);
        const id = context.params.id.slice(1);
        const headers = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        };

        const url = `appdata/${storage.appKey}/events/${id}`;
        let currentEvent = await requster.get(url, headers);
        currentEvent = await currentEvent.json();
        context.img = currentEvent.imageUrl;
        context.name = currentEvent.name;
        context.description = currentEvent.description;
        context.date = currentEvent.dateTime;
        context.organizer = currentEvent.creator;
        context._id = id;

        context.isLogged = storage.getData('userInfo') || false;
        if (context.isLogged) {
            context.username = JSON.parse(storage.getData('userInfo')).username;
        }
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/event/editEventPage.hbs')
        });
    }

    const postEdit = function (context) {
        const id = context.params.id.slice(1);
        eventModel.updateEvent(context.params, id)
            .then(r => {
                helper.handler(r);
                return r;
            })
            .then(async () => {
                helper.removeLoading();
                helper.showSuccess('Event edited successfully.');
                eventController.getDetails(context);
            }).catch((err) => {
                helper.handleError(err.message);
                eventController.getDetails(context);
            });
    }


    const postDelete = async function (context) {
        const id = context.params.id.slice(1);
        let currentEvent = await requster.get(`appdata/${storage.appKey}/events/${id}`, {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        });
        currentEvent = await currentEvent.json();
        const eventCreator = currentEvent.creator;
        const currentCreator = JSON.parse(storage.getData('userInfo')).username;
        if (eventCreator != currentCreator) {
            helper.handleError('You have to be creator in order to delete event');
            eventController.getEvent(context);
        }

        isLogged = storage.getData('userInfo') || false;

        if (!isLogged) {
            helper.handleError('You have to be logged in in order to delete event');
            eventController.getEvent(context);
        }

        const headers = {
            headers: {
                'content-type': 'application/json',
                'authorization': `Kinvey ${JSON.parse(storage.getData('authKey'))}`,
            }
        };
        const url = `appdata/${storage.appKey}/events/${id}`;

        requster.del(url, headers)
            .then(() => {
                homeController.getHome(context);
            });
    }

    const getJoin = async function (context) {
        const id = context.params.id.slice(1);
        const currentEvent = await eventModel.getEvent(id);
        const paramsForUpdEvent = {
            dateTime: currentEvent.dateTime,
            description: currentEvent. description,
            name: currentEvent.name,
            imageUrl: currentEvent.imageUrl,
            creator: currentEvent.creator,
            going: currentEvent.going
        }

        const currentUser = await userModel.getUser();

        const url = `user/${storage.appKey}/${JSON.parse(storage.getData('userInfo'))._id}`;
        if (currentUser.events === undefined) {
            
        eventModel.updateGoing(paramsForUpdEvent, id);
        userModel.addEvents(url, currentUser, currentEvent)
        .then(() => {
            helper.showSuccess('You joined the event!');
            homeController.getHome(context);
        });

        } else {
            if (currentUser.events.includes(currentEvent.name) === true) {
                helper.handleError('You are already going to this event');
                homeController.getHome(context);
            } else {
                
                eventModel.updateGoing(paramsForUpdEvent, id);
                userModel.addEvent(url, currentUser, currentEvent)
                    .then(() => {
                        helper.showSuccess('You joined the event!');
                        homeController.getHome(context);
                    });
            }

        }
    }

    return {
        getEvent,
        postEvent,
        getDetails,
        getEdit,
        postEdit,
        postDelete,
        getJoin,
    }
}();