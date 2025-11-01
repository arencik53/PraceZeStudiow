document.addEventListener('DOMContentLoaded', function () {
    const searchButton = document.querySelector('.search button');
    const searchInput = document.querySelector('.search input');
    const errorMessage = document.querySelector('.error_message');

    searchButton.addEventListener('click', function () {
        const city = searchInput.value.trim();
        if (!city) {
            errorMessage.textContent = 'Proszę podać nazwę miasta';
            return;
        }

        fetch(`https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=16e6e57dec9825f07e1c6a80bf813db0&units=metric&lang=pl`)
            .then(response => response.json())
            .then(data => {
                if (data.cod === 200) {
                    updateWeatherData(data);
                    errorMessage.textContent = '';
                } else {
                    errorMessage.textContent = 'Nie znaleziono miasta';
                }
            })
            .catch(error => {
                errorMessage.textContent = 'Wystąpił błąd podczas pobierania danych';
                console.error(error);
            });
    });

    searchInput.addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            event.preventDefault();
            searchButton.click();
        }
    });

    function updateWeatherData(data) {
        document.querySelector('.city_name').textContent = data.name;
        document.querySelector('.temp').textContent = `${Math.round(data.main.temp)}°C`;
        document.querySelector('.description').textContent = data.weather[0].description;
        document.querySelector('.feels_like').textContent = `${Math.round(data.main.feels_like)}°C`;
        document.querySelector('.pressure').textContent = `${data.main.pressure} hPa`;
        document.querySelector('.humidity').textContent = `${data.main.humidity}%`;
        document.querySelector('.wind_speed').textContent = `${data.wind.speed} m/s`;
        document.querySelector('.clouds').textContent = `${data.clouds.all}%`;
        document.querySelector('.visibility').textContent = `${data.visibility / 1000} km`;
        const weatherImg = document.querySelector('.weather_img');
        weatherImg.src = `https://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
        weatherImg.style.display = "block";

    }
});