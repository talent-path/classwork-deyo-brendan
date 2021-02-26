import { Component, OnInit } from '@angular/core';
import { Board, ChessBoard } from '../chess/Board';
import { Position } from '../chess/Position';
import { Piece } from '../chess/Pieces/Piece';
import { Move } from '../chess/Move';

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html',
  styleUrls: ['./chess-board.component.css']
})
export class ChessBoardComponent implements OnInit {

  firstSquareSelected: Position = null;
  secondSquareSelected: Position = null;
  chessBoard: Board = new ChessBoard();

  onSquareClicked(pos: Position): void {
    console.log(pos);

    let pieceAtPos: Piece = this.chessBoard.pieceAt(pos);

    if (this.firstSquareSelected === null) {
      if (pieceAtPos != null) {
        if (pieceAtPos.isWhite === this.chessBoard.isWhiteTurn)
          this.firstSquareSelected = pos;
      }
    }
    else {
      let possibleMove : Move = this.chessBoard.generateMoves().find(

        (move : Move) => {
            return ((move.from.row === this.firstSquareSelected.row) && (move.from.col === this.firstSquareSelected.col)
                    && move.to.row === pos.row && move.to.col === pos.col);
        }

      );

      if (possibleMove)
      {
        this.chessBoard = this.chessBoard.makeMove(possibleMove);
        this.firstSquareSelected = null;
      }

    }

  }

  constructor() { }

  ngOnInit(): void {
  }

}
