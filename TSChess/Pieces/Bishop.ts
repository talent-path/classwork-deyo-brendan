import { Board } from "../Board";
import { Move } from "../Move";
import { Piece, PieceType } from "./Piece";

export class Bishop implements Piece {

    kind : PieceType = PieceType.Bishop;

    isWhite : boolean;


    constructor( isWhite : boolean ){
        this.isWhite = isWhite;
    }
    generateMoves: (moveOn: Board, row: number, col: number) => Move[] = 
         (moveOn: Board, row: number, col: number)  => {

            let bishopMoves : Move[]  = [];

            let i = row + 1;
            let j = col + 1;

            while (i < 8 && j < 8)
            {
                if (moveOn.allSquares[i][j] === null)
                {
                    bishopMoves.push({  });
                }
            }


            return bishopMoves;
         }

}