function attachEvents() {
    const locationElement = document.querySelector('#location');
    const button = document.querySelector('#submit');
    let location = '';
    const currentConditionsDiv = document.querySelector('#current');
    const forecastDiv = document.querySelector('#forecast');
    const upcomingElement = document.querySelector('#upcoming');
    const url = 'https://judgetests.firebaseio.com/locations.json';
    const forecastInfoEl = document.createElement('div');
    forecastInfoEl.classList.add('forecast-info');

    const currentForecast = document.createElement('div');
    currentForecast.classList.add('forecasts');
    currentConditionsDiv.appendChild(currentForecast);

    button.addEventListener('click', () => {
        location = locationElement.value;
        locationElement.value = '';
        fetch(url)
            .then((response) => response.json())
            .then((data) => getTownForecast(data))
            .catch((err) => {
                forecastDiv.style.display = 'block';
                forecastInfoEl.innerHTML = '';
                currentForecast.innerHTML = '';
                currentForecast.innerHTML = err.message;
            });
    });

    function getTownForecast(townsObjects) {
        const keys = Object.keys(townsObjects);
        let townToSearch;

        for (const key of keys) {
            const currentTown = townsObjects[key].name;
            if (location === currentTown) {
                townToSearch = townsObjects[key];
                break;
            }
        }

        if (townToSearch === undefined) {
            throw Error('Town not found!');
        }

        forecastDiv.style.display = 'block';
        
        
        const townCode = townToSearch.code;
        const currentConditionsUrl = `https://judgetests.firebaseio.com/forecast/today/${townCode}.json`;
        fetch(currentConditionsUrl)
            .then((response) => response.json())
            .then((data) => showCurrentConditions(data));


        const threeDaysUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${townCode}.json`;
        fetch(threeDaysUrl)
            .then((response) => response.json())
            .then((data) => {
                forecastInfoEl.innerHTML = '';
                let days = Array.from(data.forecast);
                for (const day of days) {
                    const currentSpan = document.createElement('span');
                    currentSpan.classList.add('upcoming');
                    const currentWeatherCode = getCode(day.condition);

                    const symbolSpan = document.createElement('span');
                    symbolSpan.classList.add('symbol');
                    symbolSpan.innerHTML = currentWeatherCode;

                    const weatherSpan = document.createElement('span');
                    weatherSpan.classList.add('forecast-data');
                    weatherSpan.innerHTML = `${day.low}°/${day.high}°`;

                    const conditionSpanElement = document.createElement('span');
                    conditionSpanElement.classList.add('forecast-data');
                    conditionSpanElement.innerHTML = day.condition;

                    currentSpan.appendChild(symbolSpan);
                    currentSpan.appendChild(weatherSpan);
                    currentSpan.appendChild(conditionSpanElement);
                    forecastInfoEl.appendChild(currentSpan);
                    upcomingElement.appendChild(forecastInfoEl);
                }
            });
    }

    function showCurrentConditions(obj) {
        const name = obj.name;
        const forecast = obj.forecast;
        let currentWeatherCode = getCode(forecast.condition);

        currentForecast.innerHTML = '';
        const fragment = document.createDocumentFragment();

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('symbol');
        symbolSpan.innerHTML = currentWeatherCode;
        currentForecast.appendChild(symbolSpan);

        const locationSpan = document.createElement('span');
        locationSpan.classList.add('forecast-data');
        locationSpan.innerHTML = name;
        conditionSpan.appendChild(locationSpan);

        const weatherSpan = document.createElement('span');
        weatherSpan.classList.add('forecast-data');
        weatherSpan.innerHTML = `${forecast.low}°/${forecast.high}°`;
        conditionSpan.appendChild(weatherSpan);

        const conditionSpanElement = document.createElement('span');
        conditionSpanElement.classList.add('forecast-data');
        conditionSpanElement.innerHTML = forecast.condition;
        conditionSpan.appendChild(conditionSpanElement);

        fragment.appendChild(conditionSpan);
        currentForecast.appendChild(fragment);
        currentConditionsDiv.appendChild(currentForecast);
        return currentConditionsDiv;
    }

    function getCode(condition) {
        let currentWeatherCode = '';

        switch (condition) {
            case 'Sunny': {
                currentWeatherCode = '&#x2600';
                break;
            }
            case 'Partly sunny': {
                currentWeatherCode = '&#x26C5';
                break;
            }
            case 'Overcast': {
                currentWeatherCode = '&#x2601';
                break;
            }
            case 'Rain': {
                currentWeatherCode = '&#x2614';
                break;
            }
            case 'Degrees': {
                currentWeatherCode = '&#176';
                break;
            }
        }

        return currentWeatherCode;
    }
}

attachEvents();