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
exports.Knight = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var Knight = /** @class */ (function (_super) {
    __extends(Knight, _super);
    function Knight(isWhite) {
        var _this = _super.call(this, Piece_1.PieceType.Knight, isWhite) || this;
        _this.generateMoves = function (moveOn, loc) {
            var knightMoves = [];
            var knightDirections = [];
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
            for (var _i = 0, knightDirections_1 = knightDirections; _i < knightDirections_1.length; _i++) {
                var direction = knightDirections_1[_i];
                var directionMoves = Knight.jumpPiece(moveOn, loc, direction, _this.isWhite);
                knightMoves.push.apply(knightMoves, directionMoves);
            }
            return knightMoves;
        };
        return _this;
    }
    Knight.isOnBoard = function (loc) {
        return loc.col >= 0 && loc.col < 8 && loc.row >= 0 && loc.row < 8;
    };
    Knight.jumpPiece = function (moveOn, loc, dir, isWhite) {
        var allMoves = [];
        var currentLoc = { row: loc.row + dir.row, col: loc.col + dir.col };
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
    };
    return Knight;
}(ChessPiece_1.ChessPiece));
exports.Knight = Knight;
