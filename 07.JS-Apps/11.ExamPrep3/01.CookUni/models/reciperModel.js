const recipeModel = function() {
    const create = function(params) {
        let ingredients = params.ingredients.split(', ');
        const body = {
            category: params.category,
            description: params.description,
            foodImageURL: params.foodImageURL,
            ingredients: ingredients,
            meal: params.meal,
            prepMethod: params.prepMethod,
            likes: 0,
        };

        const url = `/appdata/${storage.appKey}/recipes`;
        const headers = {
            headers: {},
            body: JSON.stringify(body),
        }

        return requester.post(url, headers);
    }

    const getAllRecipes = function() {
        const headers = {
            headers: {},
        }
        const url = `/appdata/${storage.appKey}/recipes`;

        return requester.get(url, headers);
    }

    const getRecipe = function(id) {
        const headers = {
            headers: {},
        }
        const url = `/appdata/${storage.appKey}/recipes/${id}`;

        return requester.get(url, headers);
    }

    const edit = function(params) {
        let ingredients = params.ingredients.split(', ');
        const body = {
            category: params.category,
            description: params.description,
            foodImageURL: params.foodImageURL,
            ingredients: ingredients,
            meal: params.meal,
            prepMethod: params.prepMethod,
            likes: 0,
        };

        const url = `/appdata/${storage.appKey}/recipes/${params.id}`;
        const headers = {
            headers: {},
            body: JSON.stringify(body),
        }

        return requester.put(url, headers);
    }

    const del = function(id) {
        const url = `/appdata/${storage.appKey}/recipes/${id}`;
        const headers = {
            headers: {},
        }

        return requester.del(url, headers);
    }

    return {
        create,
        getAllRecipes,
        getRecipe,
        edit,
        del
    }
}();