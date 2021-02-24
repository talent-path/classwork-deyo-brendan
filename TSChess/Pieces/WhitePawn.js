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
exports.WhitePawn = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var WhitePawn = /** @class */ (function (_super) {
    __extends(WhitePawn, _super);
    function WhitePawn() {
        var _this = _super.call(this, Piece_1.PieceType.Pawn, true) || this;
        _this.generateMoves = function (moveOn, loc) {
            var whitePawnMoves = [];
            var whitePawnDirections = [];
            whitePawnDirections.push({ row: 1, col: 1 });
            whitePawnDirections.push({ row: 1, col: -1 });
            whitePawnDirections.push({ row: 1, col: 0 });
            whitePawnDirections.push({ row: 2, col: 0 });
            for (var _i = 0, whitePawnDirections_1 = whitePawnDirections; _i < whitePawnDirections_1.length; _i++) {
                var direction = whitePawnDirections_1[_i];
                var directionMoves = WhitePawn.movePiece(moveOn, loc, direction, _this.isWhite);
                whitePawnMoves.push.apply(whitePawnMoves, directionMoves);
            }
            return whitePawnMoves;
        };
        return _this;
    }
    WhitePawn.isOnBoard = function (loc) {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    };
    WhitePawn.movePiece = function (moveOn, loc, dir, isWhite) {
        var allMoves = [];
        var currentLoc = { row: loc.row + dir.row, col: loc.col + dir.col };
        // && if piece going on piece that is different color
        if (WhitePawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) === null ||
            ((WhitePawn.isOnBoard(currentLoc) && moveOn.pieceAt(currentLoc) !== null)
                && !(moveOn.pieceAt(loc).isWhite))) {
            allMoves.push({ from: loc, to: currentLoc });
            currentLoc = { row: currentLoc.row + dir.row, col: currentLoc.col + dir.col };
        }
        if (WhitePawn.isOnBoard(currentLoc)) {
            if (moveOn.pieceAt(currentLoc).isWhite != isWhite) {
                allMoves.push({ from: loc, to: currentLoc });
            }
        }
        return allMoves;
    };
    return WhitePawn;
}(ChessPiece_1.ChessPiece));
exports.WhitePawn = WhitePawn;
