const getWeather = function() {

    const zipcode = $("#zip").val();

    $.get(

        `http://api.openweathermap.org/data/2.5/weather?zip=${zipcode},US&appid=a2518a3df43cf0587826991dc6b6ccb0&units=imperial`,
        function(data, textStatus, jqXHR) {

            $("#reportHeader").text(`Weather Report for ${data.name}`);
            $("#weatherDesc").text(data.weather[0].description);

            let imageUrl = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;

            $("#weatherIcon").attr("src", imageUrl);

            $("#currentTemp").text(`${data.main.temp} degrees`);

            console.log(data);
            console.log(textStatus);
            console.log(jqXHR);
        }
    )

}

