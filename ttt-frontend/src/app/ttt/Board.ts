import { Move } from '../ttt/Move';
import { Position } from '../ttt/Position';
import { Symbol, SymbolType } from '../ttt/Symbol';
import { TTTSymbol } from '../ttt/TTTSymbol';

export interface Board {

    allSquares: Symbol[][];

    isXTurn : boolean;


    makeMove: (this: Board, toMake: Move) => Board;
    symbolAt: (loc: Position) => Symbol;
    
}

export class TTTBoard implements Board {

    allSquares: Symbol[][];

    isXTurn : boolean = true;

    symbolAt(loc: Position) : Symbol {
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


    makeMove: (toMake: Move) => Board = toMake => {

        let nextBoard: TTTBoard = new TTTBoard(this);


        let oldSymbol: Symbol = nextBoard.allSquares[toMake.from.row][toMake.from.col];

        nextBoard.allSquares[toMake.from.row][toMake.from.col] = null;

        nextBoard.allSquares[toMake.to.row][toMake.to.col] = oldSymbol;

        nextBoard.isXTurn = !this.isXTurn;


        return nextBoard;
    }


}