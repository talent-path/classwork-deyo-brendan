import { Component, OnInit } from '@angular/core';
import { Board, TTTBoard } from '../ttt/Board';
import { Position } from '../ttt/Position';
import { TTTSymbol } from '../ttt/TTTSymbol';
import { Move } from '../ttt/Move';
import { $ } from 'protractor';


@Component({
  selector: 'app-ttt-board',
  templateUrl: './ttt-board.component.html',
  styleUrls: ['./ttt-board.component.css']
})
export class TttBoardComponent implements OnInit {

  xWins : number = 0;
  oWins : number = 0;
  nDraws : number = 0;
  oldDiv = document.getElementById("win");
  resetBoard : Board = new TTTBoard();
  isDraw: boolean = false;
  isWinner: boolean = false;
  boxCount: number = 0;
  selectSquare: Position = null;
  tttBoard: Board = new TTTBoard();

  onSquareClicked(pos: Position): void {

    if (this.tttBoard.allSquares[pos.row][pos.col] === null && this.boxCount !== 9 
            && !TttBoardComponent.getWinner(this.tttBoard)) 
    {
      console.log(pos);
      console.log(this.boxCount);

      this.boxCount++;

      let newBoard : Board = this.tttBoard.makeMove(pos);

      this.tttBoard = newBoard;

      if (TttBoardComponent.getWinner(newBoard)) 
      {
        if (this.tttBoard.isXTurn) 
        {
          console.log("Player O Wins");
          this.oWins++;
          let node = document.createElement("h1");
          let text = document.createTextNode("Player O Wins!");
          node.appendChild(text);
          document.getElementById("win").appendChild(node);
          this.printStats();
        }
        else 
        {
          console.log("Player X Wins");
          this.xWins++;
          let node = document.createElement("h1");
          let text = document.createTextNode("Player X Wins!");
          node.appendChild(text);
          document.getElementById("win").appendChild(node);
          this.printStats();
        }
      }
      // draw
      if (!TttBoardComponent.getWinner(newBoard) && this.boxCount === 9) 
      {
          console.log("Draw");
          this.nDraws++;
          let node = document.createElement("h1");
          let text = document.createTextNode("DRAW");
          node.appendChild(text);
          document.getElementById("win").appendChild(node);
          this.printStats();
      }
    }
  }

  startNewGame(): void {
    
    this.tttBoard = this.resetBoard;
    this.boxCount = 0;
    document.getElementById("win").innerHTML = "";
    document.getElementById("stats").innerHTML = "";

  }

  printStats() : void {

    let statNode = document.createElement("h3");
    let statText = document.createTextNode("Number of X Wins: " + this.xWins);
    statNode.appendChild(statText);
    document.getElementById("stats").appendChild(statNode);
    let statNode2 = document.createElement("h3");
    let statText2 = document.createTextNode("Number of O Wins: " + this.oWins);
    statNode2.appendChild(statText2);
    document.getElementById("stats").appendChild(statNode2);
    let statNode3 = document.createElement("h3");
    let statText3 = document.createTextNode("Number of Draws: " + this.nDraws);
    statNode3.appendChild(statText3);
    document.getElementById("stats").appendChild(statNode3);


  }

  static getWinner(board: Board): boolean {

    // let winBoard = [
    //   [0, 1, 2],
    //   [3, 4, 5],
    //   [6, 7, 8],
    //   [0, 3, 6],
    //   [1, 4, 7],
    //   [2, 5, 8],
    //   [0, 4, 8],
    //   [2, 4, 6]
    // ];

    if ((board.allSquares[0][0] &&  board.allSquares[0][1] && board.allSquares[0][2]) 
        && (board.allSquares[0][0].isX == board.allSquares[0][1].isX 
        && board.allSquares[0][0].isX == board.allSquares[0][2].isX)) {
      return true;
    } else if ((board.allSquares[0][0] && board.allSquares[1][1] && board.allSquares[2][2]) 
        && (board.allSquares[0][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[0][0].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[0][0] && board.allSquares[1][0] && board.allSquares[2][0]) 
        && (board.allSquares[0][0].isX == board.allSquares[1][0].isX 
        && board.allSquares[0][0].isX == board.allSquares[2][0].isX)) {
      return true;
    } else if ((board.allSquares[2][0] && board.allSquares[2][1] && board.allSquares[2][2]) 
        && (board.allSquares[2][0].isX == board.allSquares[2][1].isX 
        && board.allSquares[2][0].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[2][0] && board.allSquares[1][1] && board.allSquares[0][2]) 
        && (board.allSquares[2][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[2][0].isX == board.allSquares[0][2].isX)) {
      return true;
    } else if ((board.allSquares[0][2] && board.allSquares[1][2] && board.allSquares[2][2]) 
        && (board.allSquares[0][2].isX == board.allSquares[1][2].isX 
        && board.allSquares[0][2].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[0][1] && board.allSquares[1][1] && board.allSquares[2][1]) 
        && (board.allSquares[0][1].isX == board.allSquares[1][1].isX 
        && board.allSquares[0][1].isX == board.allSquares[2][1].isX)) {
      return true;
    } else if ((board.allSquares[1][0] && board.allSquares[1][1] && board.allSquares[1][2]) 
        && (board.allSquares[1][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[1][0].isX == board.allSquares[1][2].isX)) {
      return true;
    }

    return false;

  }

  constructor() { }

  ngOnInit(): void {
  }

}
