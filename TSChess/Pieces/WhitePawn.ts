import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class WhitePawn extends ChessPiece {

    constructor(){
        super(PieceType.Pawn, true);
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
    (moveOn: Board, loc: Position)  => {
    
        let whitePawnMoves : Move[] = [];

        let whitePawnDirections : Position[] = [];

        whitePawnDirections.push( {row : 1, col: 1} );
        whitePawnDirections.push( {row : 1, col: -1} );
        whitePawnDirections.push( {row : 1, col: 0} );
        whitePawnDirections.push( {row : 2, col: 0} );

        for( let direction of whitePawnDirections ){
            let directionMoves : Move[] = WhitePawn.slidePiece( moveOn, loc, direction, this.isWhite );

            

            whitePawnMoves.push( ...directionMoves );
        }

        return whitePawnMoves;
    }

    static slidePiece: (moveOn : Board, loc : Position, dir : Position, isWhite : boolean ) =>  Move[] = 
        ( moveOn : Board, loc : Position, dir : Position, isWhite: boolean ) : Move[] => {

            let allMoves : Move[] = [];

            let currentLoc : Position = { row : loc.row + dir.row, col : loc.col + dir.col };

            while( WhitePawn.isOnBoard( currentLoc ) && moveOn.pieceAt(currentLoc) === null ){
                allMoves.push( { from: loc, to: currentLoc  });
                currentLoc = { row: currentLoc.row + dir.row, col : currentLoc.col + dir.col };
            }

            if( WhitePawn.isOnBoard( currentLoc )){
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