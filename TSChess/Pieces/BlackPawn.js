"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
exports.BlackPawn = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var BlackPawn = /** @class */ (function (_super) {
    __extends(BlackPawn, _super);
    function BlackPawn() {
        var _this = _super.call(this, Piece_1.PieceType.Pawn, false) || this;
        _this.generateMoves = function (moveOn, loc) {
            var blackPawnMoves = [];
            var blackPawnDirections = [];
            blackPawnDirections.push({ row: 1, col: 1 });
            blackPawnDirections.push({ row: 1, col: -1 });
            blackPawnDirections.push({ row: 1, col: 0 });
            blackPawnDirections.push({ row: 2, col: 0 });
            for (var _i = 0, blackPawnDirections_1 = blackPawnDirections; _i < blackPawnDirections_1.length; _i++) {
                var direction = blackPawnDirections_1[_i];
                var directionMoves = BlackPawn.movePiece(moveOn, loc, direction, _this.isWhite);
                blackPawnMoves.push.apply(blackPawnMoves, directionMoves);
            }
            return blackPawnMoves;
        };
        return _this;
    }
    BlackPawn.isOnBoard = function (loc) {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    };
    // movePiece, only 1 spot (if statement)
    BlackPawn.movePiece = function (moveOn, loc, dir, isWhite) {
        var allMoves = [];
        var currentLoc = { row: loc.row + dir.row, col: loc.col + dir.col };
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
    };
    return BlackPawn;
}(ChessPiece_1.ChessPiece));
exports.BlackPawn = BlackPawn;
