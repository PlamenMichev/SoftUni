function attachEvents() {
    const loadBtn = document.querySelector('#btnLoadPosts');
    const viewBtn = document.querySelector('#btnViewPost');
    const dropdownMenuElement = document.querySelector('#posts');
    const postElement = document.querySelector('#post-title');
    const contentElement = document.querySelector('#post-body');
    const commentsElement = document.querySelector('#post-comments');
    let allComments = [];

    const commentUrl = 'https://blog-apps-c12bf.firebaseio.com/comments.json';
    fetch(commentUrl)
        .then((response) => response.json())
        .then((data) => {
            allComments = data;
            console.log(allComments)
        });

    loadBtn.addEventListener('click', () => {
        dropdownMenuElement.innerHTML = '';
        const url = 'https://blog-apps-c12bf.firebaseio.com/posts.json';
        fetch(url)
            .then((response) => {

                dropdownMenuElement.innerHTML = '';
                if (response.status >= 400) {
                    throw Error('Execution has failed!');
                }

                return response.json();
            })
            .then((data) => createOptions(data))
            .catch((err) => postElement.innerHTML = err.message);;
    });

    viewBtn.addEventListener('click', () => {
        const postId = dropdownMenuElement[dropdownMenuElement.selectedIndex].id;
        const url = `https://blog-apps-c12bf.firebaseio.com/posts/${postId}.json`;
        let currentPost = {};
        fetch(url)
            .then((response) => {
                if (response.status >= 400) {
                    throw Error('Execution has failed!');
                }

                return response.json();
            })
            .then((data) => {
                currentPost = data;
            })
            .then(() => {
                const currentId = currentPost.id;
                postElement.innerHTML = currentPost.title;
                contentElement.innerHTML = currentPost.body;
                const fragment = document.createDocumentFragment();
                commentsElement.innerHTML = '';
                for (const comment of Array.from(Object.keys(allComments))) {
                    const commentId = allComments[comment].postId;
                    if (currentId === commentId) {
                        const ulElement = document.createElement('li');
                        ulElement.innerHTML = allComments[comment].text;
                        fragment.appendChild(ulElement);
                    }
                }

                commentsElement.appendChild(fragment);
            })
            .catch((err) => postElement.innerHTML = err.message);
    });

    function createOptions(posts) {
        const fragment = document.createDocumentFragment();
        const keys = Object.keys(posts);
        keys.forEach((key) => {
            const opElement = document.createElement('option');
            opElement.innerHTML = posts[key].title;
            opElement.id = key;
            fragment.appendChild(opElement);
        });

        dropdownMenuElement.appendChild(fragment);
    }
}

attachEvents();