const movieModel = function() {
    const create = function(params) {
        const url = `/appdata/${storage.appKey}/movies`;
        const headers = {
            body: JSON.stringify({
                title: params.title,
                imageUrl: params.imageUrl,
                description: params.description,
                genres: params.genres,
                tickets: +params.tickets,
            }),
            headers: {},
        }

        return requester.post(url, headers);
    };

    const getAllMovies = function() {
        const sortCriteria = JSON.stringify({
            tickets: -1
        })
        const url = `/appdata/${storage.appKey}/movies?query={}&sort=${sortCriteria}`;
        const headers = {
            headers: {
            }
        }

        return requester.get(url, headers);
    }

    const getMovie = function(id) {
        const url = `/appdata/${storage.appKey}/movies/${id}`;
        const headers = {
            headers: {},
        }

        return requester.get(url, headers);
    }

    const edit = function(params, id) {
        const url = `/appdata/${storage.appKey}/movies/${id}`;
        const headers = {
            body: JSON.stringify({
                title: params.title,
                imageUrl: params.imageUrl,
                description: params.description,
                genres: params.genres,
                tickets: +params.tickets,
            }),
            headers: {},
        }

        return requester.put(url, headers);
        
    }

    const del = function(id) {
        const url = `/appdata/${storage.appKey}/movies/${id}`;
        const headers = {
            headers: {}
        };

        return requester.del(url, headers);
    }

    return {
        create,
        getAllMovies,
        getMovie,
        edit,
        del
    }
}();