export enum SymbolType{
    X,
    O
}

export interface TTTSymbol{
    kind : SymbolType;
    isX : boolean;
}