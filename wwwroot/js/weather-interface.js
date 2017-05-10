var apiKey = "fa04998c118d8986d05549418958fabf";

$(document).ready(function () {
    $('#weather-location').click(function () {
        var city = $('#location').val();
        $('#location').val("");
        $('.showWeather').text("The city you have chosen is " + city + ".");
        $.ge
        t('http://api.openweathermap.org/data/2.5/weather?q=' + city + '&appid=' + apiKey, function (response) {
            console.log(response)
                $('.showWeather').text("The humidity in " + city + " is " + response.main.humidity + "%");
        });
    });
});