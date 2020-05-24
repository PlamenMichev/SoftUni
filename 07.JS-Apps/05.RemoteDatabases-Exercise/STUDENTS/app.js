elements = {
    firstNameInput: document.querySelectorAll('form input')[0],
    lastNameInput: document.querySelectorAll('form input')[1],
    facultyNumberInput: document.querySelectorAll('form input')[2],
    gradeInput: document.querySelectorAll('form input')[3],
    submitBtn: document.querySelector('button'),
    tableBody: document.querySelector('#results tbody')
};

const appId = 'kid_SyHI0W7zB';
const appSecret = 'cd4eb978002d49b1912edda64cbc33c6';
const base64NameAndPass = 'Z3Vlc3Q6Z3Vlc3Q=';
let currentId = 1;

const addStudent = function addStudent(ev) {
    ev.preventDefault();
    try {
        if (check() === false) {
            throw Error('All information is required!');
        }

        elements.submitBtn.disabled = true;

        const url = `https://baas.kinvey.com/appdata/${appId}/students`;
        fetch(url, {
            headers: { 'content-type': 'application/json', 'authorization': `Basic ${base64NameAndPass}` },
        })
            .then((response) => response.json())
            .then((data) => {
                const keys = Object.keys(data);
                console.log(keys)
                currentId = keys.length + 1;
                
                console.log(currentId)
            })
            .then(() =>
                fetch(url, {
                    method: 'post',
                    headers: { 'content-type': 'application/json', 'authorization': `Basic ${base64NameAndPass}` },
                    body: JSON.stringify({
                        ID: currentId,
                        FirstName: elements.firstNameInput.value,
                        LastName: elements.lastNameInput.value,
                        FacultyNumber: elements.facultyNumberInput.value,
                        Grade: elements.gradeInput.value,
                    }),
                })
                    .then(() => {
                        console.log(currentId);
                        const currentElement = createTrElement(elements.firstNameInput.value,
                            elements.lastNameInput.value,
                            elements.facultyNumberInput.value,
                            elements.gradeInput.value,
                            currentId);

                        elements.tableBody.appendChild(currentElement);
                    })
                    .then(() => {
                        elements.submitBtn.disabled = false;
                    }));


    } catch (error) {
        elements.tableBody.innerHTML = error.message;
    }
}

function check() {
    if (elements.firstNameInput.value === '' ||
        elements.lastNameInput.value === '' ||
        elements.facultyNumberInput.value === '' ||
        elements.gradeInput.value === '') {
        return false;
    }

    return true;
}

function createTrElement(firstName, secName, facultyNumber, grade, id) {
    const element = document.createElement('tr');
    element.innerHTML =
        `
    <td>${id}</td>
    <td>${firstName}</td>
    <td>${secName}</td>
    <td>${facultyNumber}</td>
    <td>${grade}</td>
    `;

    return element;
}

elements.submitBtn.addEventListener('click', addStudent);