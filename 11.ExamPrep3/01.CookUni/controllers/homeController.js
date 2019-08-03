const homeController = function () {

    const getHome = async function (context) {
        helper.isLogged(context);

        if (context.loggedIn) {
            let recipes = await recipeModel.getAllRecipes();
            recipes = await recipes.json();
            context.recepies = recipes;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
            recipe: "../views/recipe/recipe.hbs"
        }).then(function(){
            this.partial('../views/home/home.hbs')
        })
    };

    return {
        getHome
    }
}();