const teamController = function () {
    const getCatalog = async function (context) {
        context.loggedIn = storage.getData('authToken') !== null;
        context.hasNoTeam = false;
        context.loadPartials({
            header: '../views/common/header.hbs',
            footer: '../views/common/footer.hbs',
            team: '../views/catalog/team.hbs'
        }).then(function () {
            teamModel.getTeams(storage.getData('userInfo'))
                .then((r) => r.json())
                .then((data) => {
                    if (data.team == null) {
                        context.hasNoTeam = true;
                        data['team'] = null;
                    }
                }).then(async () => {
                    const url = `/appdata/${storage.appKey}/teams`;
                    headers = {
                        headers: {},
                    }


                    const request = await requester.get(url, headers);
                    context.teams = await request.json();
                    this.partial('../views/catalog/teamCatalog.hbs');
                });

        });
    }

    const showTeam = function (context) {
        context.loggedIn = storage.getData('authToken') !== null;
        context.loadPartials({
            header: '../views/common/header.hbs',
            createForm: '../views/create/createForm.hbs',
            footer: '../views/common/footer.hbs',
        }).then(function () {
            this.partial('../views/create/createPage.hbs');
        });
    }

    const createTeam = function (context) {
        let createdTeam = {};
        teamModel.createTeam(context)
            .then((r) => r.json())
            .then((team) => {
                createdTeam = team;
                const id = JSON.parse(storage.getData('userInfo'))._id;
                const authToken = JSON.parse(storage.getData('userInfo'))._kmd.authtoken;
                const url = `/user/${storage.appKey}/${id}`;
                const headers = {
                    body: JSON.stringify({
                        username: JSON.parse(storage.getData('userInfo')).username,
                        team: team.name,
                    }),
                    headers: {}
                }

                requester.put(url, headers);
            }).then(function () {
                const url = `/appdata/${storage.appKey}/teams/${createdTeam._id}`;
                const currentMembers = createdTeam.members;
                const currentUser = {};
                currentUser['username'] = JSON.parse(storage.getData('userInfo')).username;
                currentMembers.push(currentUser);
                const headers = {
                    body: JSON.stringify({
                        name: createdTeam.name,
                        comment: createdTeam.comment,
                        members: currentMembers,
                    }),
                    headers: {}
                }

                requester.put(url, headers);
            }).then(() =>
                getCatalog(context));
    };

    const showDetails = function (context) {
        const url = `/appdata/${storage.appKey}/teams`;
        headers = {
            headers: {},
        }

        requester.get(url, headers)
            .then(r => r.json())
            .then((data) => {
                const id = context.params.id.slice(1);
                let currentTeam = {};
                for (const team of data) {
                    if (id === team._id) {
                        currentTeam = team;
                        break;
                    }
                }

                context.name = currentTeam.name;
                context.comment = currentTeam.comment;
                context.members = currentTeam.members;
                context.isAuthor = JSON.parse(storage.getData('userInfo'))._id == currentTeam._acl.creator;
                context.isOnTeam = false;
                context.loggedIn = storage.getData('authToken') !== null;
                context.teamId = currentTeam._id;

                for (const member of currentTeam.members) {
                    if (member['username'] ==
                        JSON.parse(storage.getData('userInfo')).username) {
                        context.isOnTeam = true;
                    }
                }

                context.loadPartials({
                    header: '../views/common/header.hbs',
                    teamControls: '../views/catalog/teamControls.hbs',
                    teamMember: '../views/catalog/teamMember.hbs',
                    footer: '../views/common/footer.hbs',
                }).then(function () {
                    this.partial('../views/catalog/details.hbs');
                })
            })
    }

    const joinTeam = async function (context) {
        let id = context.params.id;
        id = id.slice(1);
        const url = `/appdata/${storage.appKey}/teams/${id}`;
        headers = {
            headers: {},
        }
        let currentTeam = {};

        requester.get(url, headers)
            .then(r => r.json())
            .then(async (team) => {
                currentTeam = team;
                const url = `/appdata/${storage.appKey}/teams/${team._id}`;
                //Checks if user has a team
                let user = await requester.get(`/user/${storage.appKey}/${JSON.parse(storage.getData('userInfo'))._id}`, { headers: {} });
                user = user.json();
                if (user.team === undefined) {
                    throw Error('You already have a team! If u want to join this team please leave ur previous one!');
                }

                const currentMembers = team.members;
                const currentUser = {};
                currentUser['username'] = JSON.parse(storage.getData('userInfo')).username;
                currentMembers.push(currentUser);
                const headers = {
                    body: JSON.stringify({
                        name: team.name,
                        comment: team.comment,
                        members: currentMembers,
                    }),
                    headers: {}
                }

                requester.put(url, headers)
                    .then(r => console.log(r));
            })
            .then(() => {
                const id = JSON.parse(storage.getData('userInfo'))._id;
                const url = `/user/${storage.appKey}/${id}`;
                const headers = {
                    body: JSON.stringify({
                        username: JSON.parse(storage.getData('userInfo')).username,
                        team: currentTeam.name,
                    }),
                    headers: {}
                }

                requester.put(url, headers);
            }).then(() =>
                getCatalog(context))
            .catch((err) => {
                getCatalog(context);
                document.querySelector('#errorBox').disabled = false;
                document.querySelector('#errorBox').innerHTML = err.message;
                console.log(document.querySelector('#errorBox').disabled)
            }); 
    }

    return {
        showTeam,
        createTeam,
        getCatalog,
        showDetails,
        joinTeam,
    }
}();