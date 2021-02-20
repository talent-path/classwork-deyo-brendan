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

let reset = function() {

    $("#searchResult").empty();

}

function getRandomArbitrary(min, max) {

    return Math.random() * (max - min) + min;
  
}

const getRandomCharacterByID = function() {

    $("#searchResult").empty();

    $.get(
        `https://www.breakingbadapi.com/api/character/random`,
        function(data, textStatus, jqXHR) {

            let newName = data[0].name.split(' ').join('+');

            for (let character of data)
            {
                let characterDiv = "</div>";
                characterDiv += `<h1>${character.name}</h1>`;
                characterDiv += `<h3>Portrayed By: ${character.portrayed}</h3>`;
                characterDiv += `<h3>Status: ${character.status}</h3>`;

                characterDiv += `<img src = ${character.img}>`;

                characterDiv += `<h3 id ="quote${character.char_id}"></h3>`;
                    $.get(
                        `https://www.breakingbadapi.com/api/quote/random?author=${newName}`,
                        function(quoteData, textStatus, jqXHR) {
                                console.log(quoteData);
                                $("#quote" + character.char_id).text(`Quote: ${quoteData[0].quote}`);
                                // characterDiv += `<h3>Quote: "${data[0].quote}"</h3>`;
                        }
                    )

                characterDiv += `<h3>Birthday: ${character.birthday}</h3>`;

                characterDiv += `<h3>Nickname: ${character.nickname}</h3>`;

                characterDiv += "<h3>Season Appearances</h3>";

                for (let appearance of character.appearance)
                {
                    characterDiv += `<li>${appearance}</li>`;
                }

                characterDiv += "<h3>Occupation(s)</h3>";
                for (let occupation of character.occupation)
                {
                    characterDiv += `<li>${occupation}</li>`;
                }
                characterDiv += "<br>";
                characterDiv += "</div>";
                
                $("#searchResult").append(characterDiv);
            }
        }
    )
}

const getDeathCountByName = function() {

    $("#searchResult").empty();

    const name = $("#deathName").val();

    $.get(
        `https://www.breakingbadapi.com/api/characters?name=${name}`,
        function(data, textStatus, jqXHR) {

            let charName = data[0].name.split(' ').join('+');

            for (let dCharacter of data)
            {
                let dCharacterDiv = "</div>";
                dCharacterDiv += `<h1>${dCharacter.name}</h1>`;
                dCharacterDiv += `<h3>Portrayed By: ${dCharacter.portrayed}</h3>`;
                dCharacterDiv += `<h3>Status: ${dCharacter.status}</h3>`;

                dCharacterDiv += `<img src = ${dCharacter.img}>`;

                dCharacterDiv += `<h3 id = "deathC${dCharacter.char_id}"></h3>`;
                $.get(
                    `https://www.breakingbadapi.com/api/death-count?name=${charName}`,
                    function(deathData, textStatus, jqXHR) {
                        $("#deathC" + dCharacter.char_id).text(`Death Count: ${deathData[0].deathCount}`);
                    }
                )
                dCharacterDiv += "</div>";
                $("#searchResult").append(dCharacterDiv);
    
            }
        }
    )
}

const getCharacterByName = function() {

    $("#searchResult").empty();

    const characterName = $("#characterName").val();

    $.get(
        `https://www.breakingbadapi.com/api/characters?name=${characterName}`,
        function(data, textStatus, jqXHR) {   
            
            let newName = data[0].name.split(' ').join('+');

            for (let character of data)
            {
                let characterDiv = "</div>";
                characterDiv += `<h1>${character.name}</h1>`;
                characterDiv += `<h3>Portrayed By: ${character.portrayed}</h3>`;
                characterDiv += `<h3>Status: ${character.status}</h3>`;

                characterDiv += `<img src = ${character.img}>`;

                characterDiv += `<h3 id ="quote${character.char_id}"></h3>`;
                    $.get(
                        `https://www.breakingbadapi.com/api/quote/random?author=${newName}`,
                        function(quoteData, textStatus, jqXHR) {
                                console.log(quoteData);
                                $("#quote" + character.char_id).text(`Quote: ${quoteData[0].quote}`);
                                // characterDiv += `<h3>Quote: "${data[0].quote}"</h3>`;
                        }
                    )

                characterDiv += `<h3>Birthday: ${character.birthday}</h3>`;

                characterDiv += `<h3>Nickname: ${character.nickname}</h3>`;

                characterDiv += "<h3>Season Appearances</h3>";

                for (let appearance of character.appearance)
                {
                    characterDiv += `<li>${appearance}</li>`;
                }

                characterDiv += "<h3>Occupation(s)</h3>";
                for (let occupation of character.occupation)
                {
                    characterDiv += `<li>${occupation}</li>`;
                }
                characterDiv += "<br>";
                characterDiv += "</div>";
                
                $("#searchResult").append(characterDiv);
            }
        }
    )
}