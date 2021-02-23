import { Move } from "./Move";
import { Bishop } from "./Pieces/Bishop";
import { Piece, PieceType } from "./Pieces/Piece"
import { Position } from "./Position"

export interface Board{

    allSquares : Piece[][];

    makeMove : (this: Board, toMake : Move) => Board;
}


class ChessBoard implements Board{

    //TODO: capture this in the copy constructor at some point...
    fiftyMoveCount : number;
    enPassantCaptureLoc : Position;

    allSquares : Piece[][];

    //  rnbqkbnr        7
    //  pppppppp        6
    //  ........        5
    //  ........        4
    //  ........        3
    //  ........        2
    //  PPPPPPPP        1
    //  RNBQKBNR        0

    //  01234567


    constructor( copyFrom?: ChessBoard ){
        if( copyFrom ){
            this.buildFrom( copyFrom );
        }
        this.allSquares = [];
        for( let row = 0; row < 8; row++ ){
            this.allSquares[row] = [];
            for( let col = 0; col < 8; col++ ){
                // if( row === 6 ){
                //     this.allSquares[row][col] = {kind: PieceType.Pawn, isWhite: false};
                // }
                // if( row === 1 ){
                //     this.allSquares[row][col] = {kind: PieceType.Pawn, isWhite: true};
                // }

                if( row === 1 || row === 6 ){
                    this.allSquares[row][col] = {kind: PieceType.Pawn, isWhite: row === 1 };
                }

                if( (row === 0 || row === 7) && (col === 0 || col === 7 )){
                    this.allSquares[row][col] = {kind: PieceType.Rook, isWhite: row === 0 };
                }

                if( (row === 0 || row === 7) && (col === 1 || col === 6 )){
                    this.allSquares[row][col] = {kind: PieceType.Knight, isWhite: row === 0 };
                }

                if( (row === 0 || row === 7) && (col === 2 || col === 5 )){
                    this.allSquares[row][col] = new Bishop(row === 0);
                }

                if( col === 3 && (row === 0 || row === 7) ){
                    this.allSquares[row][col] = {kind: PieceType.Queen, isWhite: row === 0 };
                }

                if( col === 4 && (row === 0 || row === 7) ){
                    this.allSquares[row][col] = {kind: PieceType.King, isWhite: row === 0 };
                }

                if( !this.allSquares[row][col] ){

                    this.allSquares[row][col] = null;
                }

            }
        }
    }

    buildFrom( toCopy : Board ) {

        // [a, b, c]
        // [[a, b, c]]
        
        this.allSquares = [];
        for( let i = 0; i < toCopy.allSquares.length; i++ ){
            this.allSquares.push( [...toCopy.allSquares[i]] );
        }
    }


    makeMove: ( toMake : Move) => Board = toMake => {

        //TODO: enpassant stuff
        //TODO: 50 move rule stuff

        let nextBoard : ChessBoard = new ChessBoard(this);


        let oldPiece : Piece = nextBoard.allSquares[toMake.from.row][toMake.from.col];

        nextBoard.allSquares[toMake.from.row][toMake.from.col] = null;
        nextBoard.allSquares[toMake.to.row][toMake.to.col] = oldPiece;



        return nextBoard;
    }

    generateMoves() : Move[] {

        let allMoves : Move[] = [];

        for( let row = 0; row < 8; row++ ){
            for( let col = 0; col < 8; col++ ){
                if( this.allSquares[row][col] ){
                    allMoves.push( ...this.allSquares[row][col].generateMoves(this, row, col)  )
                }
            }
        }

        return allMoves;
    }

}

console.log( "attempting to create a board")
let testBoard : ChessBoard = new ChessBoard();
console.log( "done creating a board:");
//console.log( testBoard );

console.log( testBoard.makeMove( { from: {row: 1, col: 3}, to: {row: 3, col: 3} } ));
console.log( testBoard );