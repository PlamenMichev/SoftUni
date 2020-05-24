function getArticleGenerator(input) {
	const divElement = document.getElementById('content');
	let index = 0;
	function nextArticle() {
		let currentArticle = document.createElement('article');
		if (index == input.length) {
			return;
		}
		currentArticle.textContent = input[index++];
		divElement.appendChild(currentArticle);
	};

	return nextArticle;
}