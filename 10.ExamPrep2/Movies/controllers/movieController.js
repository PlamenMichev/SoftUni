const movieController = function() {
    const getAdd = function(context) {
        helper.isLogged(context);

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function() {
            this.partial('../views/movie/add.hbs')
        });
    }

    const postAdd = function(context) {
        movieModel.create(context.params)
        .then(helper.handler)
        .then(() => {
            homeController.getHome(context);
        })
    }

    const getCinema = async function(context) {
        helper.isLogged(context);
        if (context.loggedIn) {
            let movies = await movieModel.getAllMovies();
            movies = await movies.json();
            context.movies = movies;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
            movie: "../views/movie/movie.hbs"
        }).then(function() {
            this.partial("../views/movie/allMovies.hbs")
        });
    }

    const getMyMovies = async function(context) {
        helper.isLogged(context);
        if (context.loggedIn) {
            let movies = await movieModel.getAllMovies();
            movies = await movies.json();
            movies = movies.filter((movie) => movie._acl.creator === JSON.parse(storage.getData('userInfo'))._id);
            context.movies = movies;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
            userMovie: "../views/user/userMovie.hbs"
        }).then(function() {
            this.partial("../views/user/movies.hbs")
        });
    }

    const getEdit = async function(context) {
        const id = context.params.id;
        helper.isLogged(context);
        if (context.loggedIn) {
            let movie = await movieModel.getMovie(id);
            movie = await movie.json();
            Object.keys(movie).forEach((key) => {
                context[key] = movie[key];
            });
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
        }).then(function() {
            this.partial("../views/movie/edit.hbs")
        });
    }

    const postEdit = function(context) {
        const id = context.params.id;
        movieModel.edit(context.params, id)
        .then(helper.handler)
        .then((data) => {
            homeController.getHome(context);
        })
    }

    const getDelete = async function(context) {
        const id = context.params.id;
        helper.isLogged(context);
        if (context.loggedIn) {
            let movie = await movieModel.getMovie(id);
            movie = await movie.json();
            Object.keys(movie).forEach((key) => {
                context[key] = movie[key];
            });
        }
        
        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
        }).then(function() {
            this.partial("../views/movie/delete.hbs")
        });

    }

    const postDelete = function(context) {
        const id = context.params.id;
        movieModel.del(id)
        .then(helper.handler)
        .then(() => {
            homeController.getHome(context);
        })
    }

    return {
        getAdd,
        postAdd,
        getCinema,
        getMyMovies,
        getEdit,
        getDelete,
        postEdit,
        postDelete,
    }
}();