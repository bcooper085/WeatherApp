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
                var htmlString;
                $(".weather").html(result.name);
                console.log(result);
            }
        })
    })
});