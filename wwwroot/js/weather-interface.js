$(function () {
    $('#get-weather').click(function () {
        event.preventDefault();
        console.log($(this).serialize());
        $.ajax({
            url: 'Home/CitySearch',
            type: 'GET',
            data: {cityName: $("#cityName").val()},
            dataType: 'json',
            success: function (result) {
                var kelvin = parseInt(result.main.temp);
                var fahrenheit = Math.round(((9 / 5) * (kelvin - 273)) + 32);
                $(".weather").html(fahrenheit);
                console.log(result);
            }
        })
    })
});