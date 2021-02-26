import { Board } from '../ttt/Board';
import { Position } from '../ttt/Position';
import { Move } from '../ttt/Move';

export enum SymbolType{
    X,
    O,
    '-'
}

export interface Symbol{
    kind : SymbolType | null;
    isX : boolean;

}