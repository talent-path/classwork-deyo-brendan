import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class BlackPawn extends ChessPiece {
    constructor() {
        super(PieceType.Pawn, false);
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] =
        (moveOn: Board, loc: Position) => {

            let blackPawnMoves: Move[] = [];

            let blackPawnDirections: Position[] = [];

            blackPawnDirections.push({ row: 1, col: 1 });
            blackPawnDirections.push({ row: 1, col: -1 });
            blackPawnDirections.push({ row: 1, col: 0 });
            blackPawnDirections.push({ row: 2, col: 0 });

            for (let direction of blackPawnDirections) {
                let directionMoves: Move[] = BlackPawn.movePiece(moveOn, loc, direction, this.isWhite);
                blackPawnMoves.push(...directionMoves);
            }

            return blackPawnMoves;
        }

    // movePiece, only 1 spot (if statement)
    static movePiece: (moveOn: Board, loc: Position, dir: Position, isWhite: boolean) => Move[] =
        (moveOn: Board, loc: Position, dir: Position, isWhite: boolean): Move[] => {

            let allMoves: Move[] = [];

            let currentLoc: Position = { row: loc.row + dir.row, col: loc.col + dir.col };

            // && if piece going on piece that is different color
            if (BlackPawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) === null ||
                ((BlackPawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) !== null)
                    && (moveOn.pieceAt(loc).isWhite))) {
                allMoves.push({ from: loc, to: currentLoc });
                currentLoc = { row: currentLoc.row + dir.row, col: currentLoc.col + dir.col };
            }

            if (BlackPawn.isOnBoard(currentLoc)) {
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