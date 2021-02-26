import { Component, OnInit } from '@angular/core';
import { Board, TTTBoard } from '../ttt/Board';
import { Position } from '../ttt/Position';
import { TTTSymbol } from '../ttt/TTTSymbol';
import { Move } from '../ttt/Move';


@Component({
  selector: 'app-ttt-board',
  templateUrl: './ttt-board.component.html',
  styleUrls: ['./ttt-board.component.css']
})
export class TttBoardComponent implements OnInit {

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
        }
        else
          console.log("Player X Wins");
      }
      // draw
      if (!TttBoardComponent.getWinner(newBoard) && this.boxCount === 9) 
      {
          console.log("Draw");
      }
    }
  }

  startNewGame(): void {
    this.isWinner = false;
    this.isDraw = false;
    this.boxCount = 0;
    this.tttBoard.isXTurn = true;

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

    if ((board.allSquares[0][0] &&  board.allSquares[0][1] && board.allSquares[0][2]) && (board.allSquares[0][0].isX == board.allSquares[0][1].isX 
        && board.allSquares[0][0].isX == board.allSquares[0][2].isX)) {
      return true;
    } else if ((board.allSquares[0][0] && board.allSquares[1][1] && board.allSquares[2][2]) && (board.allSquares[0][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[0][0].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[0][0] && board.allSquares[1][0] && board.allSquares[2][0]) && (board.allSquares[0][0].isX == board.allSquares[1][0].isX 
        && board.allSquares[0][0].isX == board.allSquares[2][0].isX)) {
      return true;
    } else if ((board.allSquares[2][0] && board.allSquares[2][1] && board.allSquares[2][2]) && (board.allSquares[2][0].isX == board.allSquares[2][1].isX 
        && board.allSquares[2][0].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[2][0] && board.allSquares[1][1] && board.allSquares[0][2]) && (board.allSquares[2][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[2][0].isX == board.allSquares[0][2].isX)) {
      return true;
    } else if ((board.allSquares[0][2] && board.allSquares[1][2] && board.allSquares[2][2]) && (board.allSquares[0][2].isX == board.allSquares[1][2].isX 
        && board.allSquares[0][2].isX == board.allSquares[2][2].isX)) {
      return true;
    } else if ((board.allSquares[0][1] && board.allSquares[1][1] && board.allSquares[2][1]) && (board.allSquares[0][1].isX == board.allSquares[1][1].isX 
        && board.allSquares[0][1].isX == board.allSquares[2][1].isX)) {
      return true;
    } else if ((board.allSquares[1][0] && board.allSquares[1][1] && board.allSquares[1][2]) && (board.allSquares[1][0].isX == board.allSquares[1][1].isX 
        && board.allSquares[1][0].isX == board.allSquares[1][2].isX)) {
      return true;
    }

    return false;

  }

  constructor() { }

  ngOnInit(): void {
  }

}
