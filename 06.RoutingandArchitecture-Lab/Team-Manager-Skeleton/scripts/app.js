const app = Sammy("#main", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);

    // User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);
    this.get('#/logout', userController.logout);
    this.get('#/catalog', teamController.getCatalog);
    this.get('#/create', teamController.showTeam);
    this.get('#/catalog/:id', teamController.showDetails);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.post('#/create', teamController.createTeam);
    this.get('#/join/:id', teamController.joinTeam);

    
});

(() => {
    app.run('#/home');
})();