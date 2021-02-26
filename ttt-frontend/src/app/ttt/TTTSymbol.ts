import { Board } from "../ttt/Board";
import { Move } from "../ttt/Move";
import { Position } from "../ttt/Position";
import { SymbolType, Symbol } from "../ttt/Symbol";


export abstract class TTTSymbol implements Symbol {
    kind : SymbolType;
    isX : boolean;

    constructor( kind : SymbolType, isX : boolean ){
        this.kind = kind;
        this.isX = isX;
    }
}
