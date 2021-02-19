let board;

const gameGuessingNum = function() {

    let allUnique = false;

    let attempt = NaN;
    let num = NaN;

    while (!allUnique)
    {
        
        attempt = Math.trunc(Math.random() * (9877 - 1023) + 1023);
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

let numToGuess = gameGuessingNum().toString().split("");

// function guessBlock(blockID)
// {
//     board = [];
    

// }

let checkNums = function()
{
    let bulls = 0;
    let cows = 0;

    let value = document.getElementById("userText").value.split("");

    let newArr = [];

    // console.log(value);
    // console.log(numToGuess);

    let blocks = document.getElementsByClassName("block");

    for (let i = 0; i < blocks.length; i++)
    {
        blocks[i].innerHTML = value[i];
        if (value[i] == numToGuess[i])
        {
            blocks[i].style.backgroundColor = "green";
        }
        else if (numToGuess.includes(value[i]))
        {
            blocks[i].style.backgroundColor = "yellow";
        }
        else
        {
            blocks[i].style.backgroundColor = "red";
        }
    }

    if (arrayEquals(value, numToGuess))
    {
        document.getElementById("hidden").style.display = "block";
    }

}

let reset = function() {

    numToGuess = gameGuessingNum().toString().split("");

    let blocks = document.getElementsByClassName("block");

    for (i of blocks)
    {
        i.style.backgroundColor = "white";
        i.innerHTML = "";
    }

}

let arrayEquals = function (a, b) {
    if (a === b) return true;
    if (a == null || b == null) return false;
    if (a.length !== b.length) return false;
    for (var i = 0; i < a.length; ++i) {
    if (a[i] !== b[i]) return false;
    }
    return true;
   }

