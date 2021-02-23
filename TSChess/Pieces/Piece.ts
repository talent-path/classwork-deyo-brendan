import { Board } from "../Board";
import {Move } from "../Move";

export enum PieceType{
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}

export interface Piece{
    kind : PieceType;
    isWhite : boolean;
    generateMoves? : ( moveOn : Board, row : number, col : number ) => Move[];
}

