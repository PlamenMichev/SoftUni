function attachEvents() {
    const elements = {
        addBtn: document.querySelector('.add'),
        anglerInput: document.querySelectorAll('#addForm input')[0],
        weightInput: document.querySelectorAll('#addForm input')[1],
        speciesInput: document.querySelectorAll('#addForm input')[2],
        locationInput: document.querySelectorAll('#addForm input')[3],
        baitInput: document.querySelectorAll('#addForm input')[4],
        captureTimeInput: document.querySelectorAll('#addForm input')[5],
        loadBtn: document.querySelector('.load'),
        catches: document.querySelector('#catches')
    }

    elements.catches.firstElementChild.style.display = 'none';

    elements.loadBtn.addEventListener('click', () => getAllElements());

    elements.addBtn.addEventListener('click', () => {
        const url = 'https://fisher-game.firebaseio.com/catches.json';
        if (elements.anglerInput.value === '' ||
            elements.weightInput.value === '' ||
            elements.speciesInput.value === '' ||
            elements.locationInput.value === '' ||
            elements.baitInput.value === '' ||
            elements.captureTimeInput.value === '') {
            throw new Error('All data is required!');
        }

        fetch(url,
            {
                method: 'post',
                body: JSON.stringify({
                    "angler": elements.anglerInput.value,
                    "weight": elements.weightInput.value,
                    "species": elements.speciesInput.value,
                    "location": elements.locationInput.value,
                    "bait": elements.baitInput.value,
                    "captureTime": elements.captureTimeInput.value
                })
            })
            .then((response) => response.json())
            .then(() => getAllElements())
            .catch((err) => console.error(err));
    });

    function getAllElements() {
        const url = 'https://fisher-game.firebaseio.com/catches.json';
        fetch(url)
            .then((response) => response.json())
            .then((data) => listCatches(data))
            .catch((err) => console.error(err.message));
    }

    function listCatches(allCatches) {
        elements.catches.innerHTML = '';
        const fragment = document.createDocumentFragment();

        Object.keys(allCatches).forEach((key) => {
            const currentDiv = createElement(allCatches[key], key);
            fragment.appendChild(currentDiv);
        });

        elements.catches.appendChild(fragment);
    }

    function createElement(entity, key) {
        const currentDiv = document.createElement('div');

        currentDiv.classList.add('catch');
        currentDiv.setAttribute('data-id', key);

        currentDiv.innerHTML = `<label>Angler</label>
        <input type="text" class="angler" value="${entity.angler}" />
        <hr>
        <label>Weight</label>      
        <input type="number" class="weight" value="${entity.weight}" />
        <hr>
        <label>Species</label>
        <input type="text" class="species" value="${entity.species}" />
        <hr>
        <label>Location</label>
        <input type="text" class="location" value="${entity.location}" />
        <hr>
        <label>Bait</label>
        <input type="text" class="bait" value="${entity.bait}" />
        <hr>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${entity.captureTime}" />
        <hr>
        <button class="update">Update</button>
        <button class="delete">Delete</button>`;

        const currentUpBtn = currentDiv.querySelectorAll('button')[0];
        const currentDelBtn = currentDiv.querySelectorAll('button')[1];

        currentUpBtn.addEventListener('click', updateItem);
        currentDelBtn.addEventListener('click', deleteItem);
        return currentDiv;
    }

    const deleteItem = function deleteCurrentItem() {
        const url = `https://fisher-game.firebaseio.com/catches/${this.parentElement.getAttribute('data-id')}.json`;
        fetch(url, {
            method: 'delete',
        });

        this.parentElement.remove();
    }

    const updateItem = function updateItem() {
        const parentInputs = {
            anglerInput: this.parentElement.querySelectorAll('input')[0],
            weightInput: this.parentElement.querySelectorAll('input')[1],
            speciesInput: this.parentElement.querySelectorAll('input')[2],
            locationInput: this.parentElement.querySelectorAll('input')[3],
            baitInput: this.parentElement.querySelectorAll('input')[4],
            captureTimeInput: this.parentElement.querySelectorAll('input')[5],
        };

        console.log(parentInputs.anglerInput.value,
             parentInputs.captureTimeInput.value, parentInputs.baitInput.value, 
             parentInputs.locationInput.value,parentInputs.speciesInput.value, parentInputs.weightInput.value)

        if (parentInputs.anglerInput.value === '' ||
            parentInputs.weightInput.value === '' ||
            parentInputs.speciesInput.value === '' ||
            parentInputs.locationInput.value === '' ||
            parentInputs.baitInput.value === '' ||
            parentInputs.captureTimeInput.value === '') {
            throw new Error('All data is required!');
        }

        const url = `https://fisher-game.firebaseio.com/catches/${this.parentElement.getAttribute('data-id')}.json`;
        fetch(url, {
            method: 'put',
            body: JSON.stringify({
                "angler": parentInputs.anglerInput.value,
                "weight": parentInputs.weightInput.value,
                "species": parentInputs.speciesInput.value,
                "location": parentInputs.locationInput.value,
                "bait": parentInputs.baitInput.value,
                "captureTime": parentInputs.captureTimeInput.value
            })
        })
            .then((response) => response.json())
            .then(() => getAllElements())
            .catch((err) => console.error(err));
    };
}

attachEvents();

