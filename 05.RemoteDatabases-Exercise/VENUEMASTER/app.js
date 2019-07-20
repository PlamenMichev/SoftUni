const elements = {
    inputElement: document.querySelector('#venueDate'),
    listBtn: document.querySelector('#getVenues'),
    appendDiv: document.querySelector('#venue-info'),
}

const appId = 'kid_BJ_Ke8hZg';
const username = 'guest';
const pass = 'pass';

const requestHeaders = {
    'content-type': 'application/json',
    'authorization': `Basic ${btoa(username + ':' + pass)}`,
}

const listData = function listData() {
    const url = `https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/calendar?query=${elements.inputElement.value}`;
    elements.appendDiv.innerHTML.innerHTML = '';
    fetch(url, {
        method: 'post',
        headers: requestHeaders,
    })
        .then((response) => response.json())
        .then((data) => {
            const keys = Object.keys(data);
            for (const key of keys) {
                const getUrl = `https://baas.kinvey.com/appdata/kid_BJ_Ke8hZg/venues/${data[key]}`
                fetch(getUrl, {
                    headers: requestHeaders,
                })
                    .then((response) => response.json())
                    .then((data) => createElement(data));
            }
        })
}

function createElement(args) {
    const name = args.name;
    const description = args.description;
    const price = args.price;
    const startingHour = args.startingHour;

    const newElement = document.createElement('div');
    newElement.classList.add('venue');
    newElement.id = args._id;

    newElement.innerHTML = `
    <span class="venue-name"><input class="info" type="button" value="More info">${name}</span>
    <div class="venue-details" style="display: none;">
        <table>
            <tr>
                <th>Ticket Price</th>
                <th>Quantity</th>
                <th></th>
            </tr>
            <tr>
                <td class="venue-price">${price} lv</td>
                <td><select class="quantity">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                    </select></td>
                <td><input class="purchase" type="button" value="Purchase"></td>
            </tr>
        </table>
        <span class="head">Venue description:</span>
        <p class="description">${description}</p>
        <p class="description">Starting time: ${startingHour}</p>
    </div>`

    const buttonInfo = newElement.querySelectorAll('input')[0];
    const buttonPurchase = newElement.querySelectorAll('input')[1];

    buttonInfo.addEventListener('click', showInfo);
    buttonPurchase.addEventListener('click', (ev) => purchase(ev, name, price, args._id));
    elements.appendDiv.appendChild(newElement);
}

const showInfo = function showInfo() {
    const currentElement = this.parentNode.parentNode;
    const elementToShow = currentElement.querySelector('div');
    if (elementToShow.style.display === 'none') {
        elementToShow.style.display = 'block'
    } else {
        elementToShow.style.display = 'none'
    }
}

function purchase(ev, name, price, id) {
    const quantity = ev.target.parentNode.parentNode.getElementsByClassName('quantity')[0];
    const firstNum = Number(quantity.value);
    const secNum = Number(price);
    console.log(firstNum, secNum);
    elements.appendDiv.innerHTML = `<span class="head">Confirm purchase</span>
    <div class="purchase-info">
        <span>${name}</span>
        <span>${quantity.value} x ${+price}</span>
        <span>Total: ${firstNum * secNum} lv</span>
        <input type="button" value="Confirm">
    </div>`;

    const confirmBtn = elements.appendDiv.querySelector('input');
    confirmBtn.addEventListener('click', () => {
        const url = `https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${id}&qty=${quantity.value}`;
        fetch(url, {
            method: 'post',
            headers: requestHeaders,
        })
        .then((response) => response.json())
        .then((data) => elements.appendDiv.innerHTML = data.html + 'You may print this page as your ticket');
    });
}
//

elements.listBtn.addEventListener('click', listData);