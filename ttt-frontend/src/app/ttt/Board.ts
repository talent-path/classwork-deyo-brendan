import { Move } from '../ttt/Move';
import { Position } from '../ttt/Position';
import { TTTSymbol, SymbolType } from '../ttt/TTTSymbol';


export interface Board {

    allSquares: TTTSymbol[][];

    isXTurn : boolean;

    makeMove: (this: Board, pos: Position) => Board;
    symbolAt: (loc: Position) => TTTSymbol;
    
}

export class TTTBoard implements Board {

    allSquares: TTTSymbol[][];

    isXTurn : boolean = true;

    symbolAt(loc: Position) : TTTSymbol {
        return this.allSquares[loc.row][loc.col];
    }

    constructor(copyFrom?: TTTBoard)
    {
        this.allSquares = [];

        if (copyFrom)
        {
            this.buildFrom(copyFrom);
        }
        else
        {
            for (let row = 0; row < 3; row++) 
            {
                this.allSquares[row] = [];
                for (let col = 0; col < 3; col++) 
                {
                    this.allSquares[row].push(null);
                }
            }

        }
    }

    buildFrom(toCopy: Board) {

        this.allSquares = [];
        for (let i = 0; i < toCopy.allSquares.length; i++) 
        {
            this.allSquares.push([...toCopy.allSquares[i]]);
        }
    }


    makeMove: (pos: Position) => Board = pos => {

        let nextBoard: TTTBoard = new TTTBoard(this);

        nextBoard.allSquares[pos.row][pos.col] = this.isXTurn ? {kind: SymbolType.X, isX : true} 
                : {kind: SymbolType.O, isX: false};

        nextBoard.isXTurn = !this.isXTurn;

        return nextBoard;
    }


}