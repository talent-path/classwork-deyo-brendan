import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class Knight extends ChessPiece {

    constructor(isWhite: boolean) {
        super(PieceType.Knight, isWhite);
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] =
        (moveOn: Board, loc: Position) => {

            let knightMoves: Move[] = [];

            let knightDirections: Position[] = [];

            // horizontal L
            knightDirections.push({ row: 1, col: 2 });
            knightDirections.push({ row: 1, col: -2 });
            knightDirections.push({ row: -1, col: 2 });
            knightDirections.push({ row: -1, col: -2 });

            // vertical L
            knightDirections.push({ row: 2, col: 1 });
            knightDirections.push({ row: -2, col: 1 });
            knightDirections.push({ row: 2, col: -1 });
            knightDirections.push({ row: -2, col: -1 });

            for (let direction of knightDirections) {
                let directionMoves: Move[] = Knight.jumpPiece(moveOn, loc, direction, this.isWhite);
                knightMoves.push(...directionMoves);
            }

            return knightMoves;
        }

    static jumpPiece: (moveOn: Board, loc: Position, dir: Position, isWhite: boolean) => Move[] =
        (moveOn: Board, loc: Position, dir: Position, isWhite: boolean): Move[] => {

            let allMoves: Move[] = [];

            let currentLoc: Position = { row: loc.row + dir.row, col: loc.col + dir.col };

            // && if piece going on piece that is different color
            if (Knight.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) === null ||
                ((Knight.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) !== null)
                    && !(moveOn.pieceAt(loc).isWhite))) {
                allMoves.push({ from: loc, to: currentLoc });
                currentLoc = { row: currentLoc.row + dir.row, col: currentLoc.col + dir.col };
            }

            if (Knight.isOnBoard(currentLoc)) {
                if (moveOn.pieceAt(currentLoc).isWhite != isWhite) {
                    allMoves.push({ from: loc, to: currentLoc });
                }
            }

            return allMoves;
        }

    static isOnBoard(loc: Position): boolean {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    }


}