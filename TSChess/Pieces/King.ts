import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class King extends ChessPiece {
    
    constructor( isWhite : boolean ){
        super( PieceType.King, isWhite );
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
    (moveOn: Board, loc: Position)  => {
    
        let kingMoves : Move[] = [];

        let kingDirections : Position[] = [];

        kingDirections.push( {row : 1, col: 0} );
        kingDirections.push( {row : -1, col: 0} );
        kingDirections.push( {row : 0, col: 1} );
        kingDirections.push( {row : 0, col: -1} );
        kingDirections.push( {row : 1, col: 1} );
        kingDirections.push( {row : 1, col: -1} );
        kingDirections.push( {row : -1, col: 1} );
        kingDirections.push( {row : -1, col: -1} );

        for( let direction of kingDirections ){
            let directionMoves : Move[] = King.slidePiece( moveOn, loc, direction, this.isWhite );
            kingMoves.push( ...directionMoves );
        }

        return kingMoves;
    }

    static slidePiece: (moveOn : Board, loc : Position, dir : Position, isWhite : boolean ) =>  Move[] = 
        ( moveOn : Board, loc : Position, dir : Position, isWhite: boolean ) : Move[] => {

            let allMoves : Move[] = [];

            let currentLoc : Position = { row : loc.row + dir.row, col : loc.col + dir.col };

            while( King.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc) === null ){
                allMoves.push( { from: loc, to: currentLoc  });
                currentLoc = { row: currentLoc.row + dir.row, col : currentLoc.col + dir.col };
            }

            if( King.isOnBoard( currentLoc )){
                if( moveOn.pieceAt(currentLoc).isWhite != isWhite  ){
                    allMoves.push( {from: loc, to: currentLoc});
                }
            }
            return allMoves;
        }

    static isOnBoard( loc : Position ) : boolean {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    }
    
}