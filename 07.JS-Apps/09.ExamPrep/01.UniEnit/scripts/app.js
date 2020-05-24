const app = Sammy('#main', function() {
    this.use('Handlebars', 'hbs');

    //Home
    this.get('#/home', homeController.getHome);

    //User
    this.get('#/register', userContoller.getRegister);
    this.get('#/logout', userContoller.postLogout);
    this.get('#/login', userContoller.getLogin);
    this.get('#/create', eventController.getEvent);
    this.get('#/details/:id', eventController.getDetails);
    this.get('#/edit/:id', eventController.getEdit);
    this.get('#/delete/:id', eventController.postDelete);
    this.get('#/join/:id', eventController.getJoin);

    this.post('#/login', userContoller.postLogin);
    this.post('#/create', eventController.postEvent);
    this.post('#/register', userContoller.postRegister);
    this.post('#/edit/:id', eventController.postEdit);
});

(() => {
    app.run('#/home')
})();