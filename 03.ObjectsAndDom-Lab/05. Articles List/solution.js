function createArticle() {
	let titleElement = document.getElementById("createTitle");
	let contentElement = document.getElementById("createContent");
	let title = titleElement.value;
	let content = contentElement.value;
	
	if (title != '' && content != '') {
		titleElement.value = '';
		contentElement.value = '';
		let newTitleElement = document.createElement('h3');
		newTitleElement.textContent = title;
		let newContentElement = document.createElement('p');
		newContentElement.textContent = content;

		let parent = document.getElementById("articles");
		let articleElement = document.createElement('article');
		articleElement.appendChild(newTitleElement);
		articleElement.appendChild(newContentElement);

		parent.appendChild(articleElement);
	}
}