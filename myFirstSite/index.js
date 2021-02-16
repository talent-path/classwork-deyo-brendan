let count = 0;

let elementToToggle = null;

let isWinner = false;

let board = ['0', '0', '0', '0', '0', '0', '0', '0', '0'];

function placeMarker(buttonId) 
{
    if (count % 2 == 0)
    {
        document.getElementById("button" + buttonId).style.background 
        = "url('https://www.clipartmax.com/png/middle/134-1340885_swarm-bee-x-delete-comments-tic-tac-toe-cross.png')";
        document.getElementById("button" + buttonId).style.backgroundSize = 'cover';
        document.getElementById("button" + buttonId).style.alignContent = 'center';

        board[document.getElementById("button" + buttonId)] = 1; // for X
        
        isWinner = checkWinner(buttonId);
        if (isWinner)
        {
            elementToToggle = document.getElementById('win1');
            elementToToggle.style.display = 'block';
        }
        else if (count == 9)
        {
            elementToToggle = document.getElementById('win3');
            elementToToggle.style.display = 'block';
        }    
    }
    else
    {
        document.getElementById("button" + buttonId).style.background 
        = "url('https://www.clipartmax.com/png/middle/440-4408148_transparent-o-tic-tac-toe-o.png')";
        document.getElementById("button" + buttonId).style.backgroundSize = 'cover';
        document.getElementById("button" + buttonId).style.alignContent = 'center';

        board[document.getElementById("button" + buttonId)] = -1; // for O

        isWinner = checkWinner(buttonId);
        if (isWinner)
        {
            elementToToggle = document.getElementById('win2');
            elementToToggle.style.display = 'block';   
        }
        else if (count == 9)
        {
            elementToToggle = document.getElementById('win3');
            elementToToggle.style.display = 'block';
        }
    }
    count++;
    console.log(buttonId);
    let toDisable = document.getElementById('button' + buttonId);
    toDisable.disabled = true;
}

// function winCondition(winId)
// {
//     let elementToToggle = null;
    
//     if ((checkWinner(buttonId) == true) && (count % 2 == 0))
//     {
//         elementToToggle = document.getElementById('win1');
//         elementToToggle.style.display = 'block';
//     }
//     else if (count >= 9)
//     {
//         elementToToggle = document.getElementById('win3');
//         elementToToggle.style.display = 'block';
//     }
//     else 
//     {
//         elementToToggle = document.getElementById('win2');
//         elementToToggle.style.display = 'block';
//     }
// }

function checkWinner(buttonId)
{
    if (board[1] == board[2] && board[1] == board[3])
        isWinner = true;
    else if (board[1] == board[4] && board[1] == board[7])
        isWinner = true;
    else if (board[1] == board[5] && board[1] == board[9])
        isWinner = true;
    else if (board[4] == board[5] && board[4] == board[6])
        isWinner = true;
    else if (board[2] == board[5] && board[2] == board[8])
        isWinner = true;
    else if (board[3] == board[6] && board[3] == board[9])
        isWinner = true;
    else if (board[7] == board[5] && board[7] == board[3])
        isWinner = true;
    else if (board[7] == board[6] && board[7] == board[9])
        isWinner = true;
    else
        return false;
}

