const homeController = function() {
    const getHome = async function(context) {
        console.log(context);
        context.isLogged = storage.getData('userInfo') || false;
        if (context.isLogged) {
            context.username = JSON.parse(storage.getData('userInfo')).username;
            context.events = await eventModel.getAllEvents();
        }

        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
            eventElement: '../views/event/eventElement.hbs',
        }).then(function() {
            this.partial('../views/home/home.hbs')
        });
    }

    return {
        getHome,
    }
}();