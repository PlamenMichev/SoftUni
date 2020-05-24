const userContoller = function () {

    const getRegister = function (context) {

        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/user/signUp.hbs')
        })
    }

    const getLogin = function (context) {

        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/user/signIn.hbs')
        })
    }

    const postRegister = function (context) {
        helper.showLoading();
        debugger;
        userModel.register(context.params)
        .then(helper.handler)
            .then(async (data) => {
                storage.saveUser(data);
                helper.removeLoading();
                helper.showSuccess('Register successful.');
                homeController.getHome(context);
            })
            .catch((err) => {
                helper.handleError(err.message);
                userContoller.getRegister(context);
            });
    }

    const postLogin = function (context) {
        helper.showLoading();
        userModel.login(context.params)
            .then(r => {
                helper.handler(r);
                return r;
            })
            .then(async (data) => {
                data = await data.json();
                storage.saveUser(data);
                helper.removeLoading();
                helper.showSuccess('Login successful.');
                homeController.getHome(context);
            }).catch((err) => {
                helper.handleError(err.message);
                homeController.getHome(context);
            });
    }

    const postLogout = function(context) {

        userModel.logout(context)
        .then(r => {
            helper.handler(r);
            return r;
        })
        .then(async () => {
            storage.deleteUser();
            helper.removeLoading();
            helper.showSuccess('Logout successful.');
            homeController.getHome(context);
        }).catch((err) => {
            helper.handleError(err.message);
            homeController.getHome(context);
        });
    }

    return {
        getRegister,
        getLogin,
        postRegister,
        postLogin,
        postLogout,
    }
}();