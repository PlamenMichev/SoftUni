const userController = function () {

    const getRegister = function (context) {

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/register/registerPage.hbs')
        })
    };

    const getLogin = function (context) {
        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/login/loginPage.hbs');
        })
    };

    const getCatalog = function (context) {
        context.loggedIn = storage.getData('authToken') !== null;
        context.hasNoTeam = false;
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs'
        }).then(function () {
            userModel.getTeams(storage.getData('userInfo'))
                .then((r) => r.json())
                .then((data) => {
                    if (data.team == null) {
                        context.hasNoTeam = true;
                        data['team'] = null;
                    }
                }).then(() => {
                    this.partial('../views/catalog/teamCatalog.hbs');
                });

        });
    }

    const showTeam = function (context) {
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
            createForm: '../views/create/createForm.hbs'
        }).then(function () {
            this.partial('../views/create/createPage.hbs');
        });
    }

    const createTeam = function (context) {
        teamModule.createTeam(context)
            .then((team) => {
                const id = JSON.parse(storage.getData('userInfo'))._id;
                const authToken = JSON.parse(storage.getData('userInfo'))._kmd.authtoken;
                const url = `/user/${storage.appKey}/${id}`
                const headers = {
                    headers: {},
                    Authorization: `Kinvey ${authToken}`,
                }
                
                requester.get(url, headers)
                .then((data) => data.json())
                .then((data) => {
                    (Object.keys(data)).push('team');
                    data['team'] = context.params.name;
                    console.log(data['team'])
                })
            });
    }

    const postRegister = function (context) {

        userModel.register(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                homeController.getHome(context);
            })
    };

    const postLogin = function (context) {

        userModel.login(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                homeController.getHome(context);
            })
    };

    const logout = function (context) {

        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                homeController.getHome(context);
            });
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
        getCatalog,
        createTeam,
        showTeam
    }
}();