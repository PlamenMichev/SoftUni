const teamModule = function() {
    const createTeam = function(context) {
        const url = `/appdata/${storage.appKey}/teams`;
        const name = context.params.name;
        const comment = context.params.name;
        const id = JSON.parse(storage.getData('userInfo'))._id;
        const authToken = JSON.parse(storage.getData('userInfo'))._kmd.authtoken;
        
        const headers = {
            body: JSON.stringify({
                name: name,
                comment: comment,
            }),
            Authorization: `Kinvey ${authToken}`,
            headers: {}
        }

        return requester.post(url, headers);
    }

    return {
        createTeam,
    }
}();