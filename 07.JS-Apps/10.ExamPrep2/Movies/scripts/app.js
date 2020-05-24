const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);

    // User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);
    this.get('#/logout', userController.logout);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);

    //Movies
    this.get('#/add', movieController.getAdd);
    this.get('#/cinema', movieController.getCinema);
    this.get('#/myMovies', movieController.getMyMovies);
    this.get('#/edit/:id', movieController.getEdit);
    this.get('#/delete/:id', movieController.getDelete)

    this.post('#/add', movieController.postAdd);
    this.post('#/edit/:id', movieController.postEdit)
    this.post('#/delete/:id', movieController.postDelete)
    
});

(() => {
    app.run('#/home');
})();