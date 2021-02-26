import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Bishop } from '../chess/Pieces/Bishop';
import { Piece, PieceType } from '../chess/Pieces/Piece';
import { Position } from '../chess/Position';


@Component({
  selector: 'app-chess-square',
  templateUrl: './chess-square.component.html',
  styleUrls: ['./chess-square.component.css']
})
export class ChessSquareComponent implements OnInit {

  @Output()squareClickedEvent : EventEmitter<Position> = new EventEmitter<Position>();
  @Input()squarePiece : Piece = new Bishop(true);
  imgSrc : String = "./assets/";
  @Input()row : number = 0;
  @Input()col : number = 7;
  isLightSquare : boolean = false;

  constructor() { 

  }

  ngOnInit(): void {

    if (this.squarePiece === null)
    {
      this.imgSrc = " ";
    }

    else {

      this.imgSrc += this.squarePiece.isWhite ? "w" : "b";

      switch (this.squarePiece.kind)
      {
          case PieceType.Bishop : this.imgSrc += "B";  break;
          case PieceType.Queen : this.imgSrc += "Q";  break;
          case PieceType.Pawn : this.imgSrc += "P";  break;
          case PieceType.Rook : this.imgSrc += "R";  break;
          case PieceType.Knight : this.imgSrc += "N";  break;
          case PieceType.King : this.imgSrc += "K";  break;
  
      }
  
      this.imgSrc += ".png";

    }
    this.isLightSquare = (this.row + this.col) % 2 === 0;

  }

  squareClicked() : void {

    this.squareClickedEvent.emit({row : this.row, col : this.col});

  }

}
