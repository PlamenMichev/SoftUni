const teamModel = function() {
    const createTeam = function(context) {
        const url = `/appdata/${storage.appKey}/teams`;
        const name = context.params.name;
        const comment = context.params.comment;
        const id = JSON.parse(storage.getData('userInfo'))._id;
        const authToken = JSON.parse(storage.getData('userInfo'))._kmd.authtoken;

        const headers = {
            body: JSON.stringify({
                name: name,
                comment: comment,
                members: [],
            }),
            Authorization: `Kinvey ${authToken}`,
            headers: {}
        }

        return requester.post(url, headers);
    }

    const getTeams = function (params) {
        const id = JSON.parse(params)._id;
        const authToken = JSON.parse(params).authtoken;

        const url = `/user/${storage.appKey}/${id}`;
        const headers = {
            Authorization: `Kinvey ${authToken}`,
            headers: {}
        }

        return requester.get(url, headers);
    }


    return {
        createTeam,
        getTeams,
    }
}();