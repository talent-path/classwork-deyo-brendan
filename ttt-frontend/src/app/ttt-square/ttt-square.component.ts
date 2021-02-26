import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Position } from '../ttt/Position'
import { TTTSymbol } from '../ttt/TTTSymbol';

@Component({
  selector: 'app-ttt-square',
  templateUrl: './ttt-square.component.html',
  styleUrls: ['./ttt-square.component.css']
})
export class TttSquareComponent implements OnInit {

  @Output()squareClickedEvent: EventEmitter<Position> = new EventEmitter<Position>();
  imgSrc: String = "./assets/";
  @Input()squarePiece: TTTSymbol;
  @Input()row : number;
  @Input()col : number;

  constructor() { }

  ngOnInit(): void {

    if (this.squarePiece === null) {
      this.imgSrc +=  "null.png";
    }
    else {
      if (this.squarePiece.isX) {
        this.imgSrc += "XTTT";
      }
      else
        this.imgSrc += "OTTT";

      this.imgSrc += ".png";
    }
  }

  squareClicked() : void {
    this.squareClickedEvent.emit({row : this.row, col : this.col});
  }

}
