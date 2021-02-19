let reset = function() {

    document.getElementById("displayCharacter").style.display = "none";

}

const getRandomNum = function() {

    let allUnique = false;

    let attempt = NaN;
    let num = NaN;

    while (!allUnique)
    {
        
        attempt = Math.trunc(Math.random() * (63 - 1) + 1);
        let digits = [];

        num = attempt;

        while (attempt > 0)
        {
            let digit = attempt % 10;
            attempt = Math.trunc(attempt / 10);
            digits.push(digit);
        }

        const newDigits = new Set(digits);

        allUnique = newDigits.size === 4;
    }

    return num;
}

const getRandomCharacterByID = function() {

    // $.get(
    //     `https://www.breakingbadapi.com/api/characters/${characterID}`,
    //     function(data, textStatus, jqXHR) {

    //         let imageURL = `${data[0].img}`;


    //         $("#characterImage").attr("src", imageURL);
    //         $("#char").text(`${data[0].name}`);
    //         $("#nickname").text(`${data[0].nickname}`);
    //         $("#birthday").text(`${data[0].birthday}`);
    //         $("#status").text(`${data[0].status}`);



    //         console.log(data);
    //         console.log(textStatus);
    //         console.log(jqXHR);

    //     }
    // )
    // document.getElementById("displayCharacter").style.display = "block";
}

const getCharacterByName = function() {


    const characterName = $("#characterName").val();

    $.get(
        `https://www.breakingbadapi.com/api/characters?name=${characterName}`,
        function(data, textStatus, jqXHR) {

            console.log(data);
            let imageURL = `${data[0].img}`;


            $("#characterImage").attr("src", imageURL);
            $("#char").text(`${data[0].name}`);
            $("#nickname").text(`${data[0].nickname}`);
            $("#birthday").text(`${data[0].birthday}`);
            $("#status").text(`${data[0].status}`);



            console.log(data);
            console.log(textStatus);
            console.log(jqXHR);

        }
    )
    document.getElementById("displayCharacter").style.display = "block";
}


// const getWeather = function() {

//     const zipcode = $("#zip").val();

//     $.get(

//         `http://api.openweathermap.org/data/2.5/weather?zip=${zipcode},US&appid=a2518a3df43cf0587826991dc6b6ccb0&units=imperial`,
//         function(data, textStatus, jqXHR) {

//             $("#reportHeader").text(`Weather Report for ${data.name}`);
//             $("#weatherDesc").text(data.weather[0].description);

//             let imageUrl = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;

//             $("#weatherIcon").attr("src", imageUrl);

//             $("#currentTemp").text(`${data.main.temp} degrees`);

//             console.log(data);
//             console.log(textStatus);
//             console.log(jqXHR);
//         }
//     )

// }
