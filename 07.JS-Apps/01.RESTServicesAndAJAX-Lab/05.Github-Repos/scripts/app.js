function loadRepos() {
	const xhr = new XMLHttpRequest();
	const name = document.getElementById('username').value;
	const list = document.getElementById("repos");
	list.innerHTML = '';

	const url =`https://api.github.com/users/${name}/repos`;
	fetch(url)
		.then((response) => response.json())
		.then((data) => addRepo(data));

	function addRepo(repos) {
		repos.forEach(repo => {
			const { full_name, html_url } = repo;
			let currentRepoElement = document.createElement('li');
			let currentUrl = document.createElement('a');
			currentUrl.textContent = full_name;
			currentUrl.href = html_url;
			currentRepoElement.appendChild(currentUrl);
			list.appendChild(currentRepoElement);
			console.log(currentRepoElement);
		});
	}
}