const app = Sammy("#rooter", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);

    // User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.get('#/logout', userController.logout);

    //Recipers
    this.get('#/createRecipe', reciperController.getCreate);
    this.get('#/details/:id', reciperController.getDetails);
    this.get('#/editMeal/:id', reciperController.getEdit);

    this.post('#/createRecipe', reciperController.postCreate);
    this.post('#/editMeal/:id', reciperController.postEdit);
    this.get('#/deleteMeal/:id', reciperController.postDelete)
    
});

(() => {
    app.run('#/home');
})();