const reciperController = function () {
    const getCreate = function (context) {
        helper.isLogged(context);

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial("../views/recipe/createRecipe.hbs");
        });
    }

    const postCreate = function (context) {
        recipeModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                context.redirect('#', 'home');
            });
    }

    const getDetails = async function (context) {
        helper.isLogged(context);
        if (context.loggedIn) {
            let recipe = await recipeModel.getRecipe(context.params.id);
            recipe = await recipe.json();
            context.isCreator = JSON.parse(storage.getData('userInfo'))._id == recipe._acl.creator;
            Object.keys(recipe).forEach((key) => {
                context[key] = recipe[key];
            });
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial("../views/recipe/details.hbs");
        });
    }

    const getEdit = async function (context) {
        helper.isLogged(context);
        if (context.loggedIn) {
            let recipe = await recipeModel.getRecipe(context.params.id);
            recipe = await recipe.json();
            Object.keys(recipe).forEach((key) => {
                if (key == 'ingredients') {
                    context[key] = recipe[key].join(', ');
                } else {
                    context[key] = recipe[key];
                }
            });
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial("../views/recipe/edit.hbs");
        });
    }

    const postEdit = function(context) {
        recipeModel.edit(context.params)
        .then(helper.handler)
        .then(() => {
            context.redirect('#/home');
        });
    }

    const postDelete = function(context) {
        recipeModel.del(context.params.id)
        .then(helper.handler)
        .then(() => {
            homeController.getHome(context);
        });
    }

    return {
        getCreate,
        postCreate,
        getDetails,
        getEdit,
        postEdit,
        postDelete,
    }
}();