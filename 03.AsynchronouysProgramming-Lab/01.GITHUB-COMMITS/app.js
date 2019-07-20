function loadCommits() {
    // Try it with Fetch API
    const username = document.querySelector('#username').value;
    const repo = document.querySelector('#repo').value;
    const url = `https://api.github.com/repos/${username}/${repo}/commits`;
    const ulElement = document.querySelector('#commits');
    ulElement.innerHTML = 'Loading...';
    fetch(url)
        .then((response) => {
            if (response.status >= 400) {
                handleError(response);
                throw new Error('Failed!');
            }

            return response.json();
        })
        .then((data) => getCommits(data))
        .catch((err) => console.log(err.message));

    function getCommits(commits) {
        const keys = Object.keys(commits);
        ulElement.innerHTML = '';
        keys.forEach((key) => {
            const currentCommit = commits[key].commit;
            const liElement = document.createElement('li');
            liElement.innerHTML = `${currentCommit.author.name}: ${currentCommit.message}`;
            ulElement.appendChild(liElement);
        });
    }

    function handleError(response) {
        ulElement.innerHTML = '';
        const liElement = document.createElement('li');
        liElement.innerHTML = `Error: ${response.status} (${response.statusText})`;
        ulElement.appendChild(liElement);
    }
}