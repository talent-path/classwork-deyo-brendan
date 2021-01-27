package com.tp.connectfour.models;

public class ConnectFourViewModel {

    private Integer gameID;
    private Integer[][] board;

    private Integer playerMove;
    private Integer computerMove;

    public ConnectFourViewModel(Integer gameID)
    {
        this.gameID = gameID;
        this.board = new Integer[6][7];

        this.playerMove = 1;
        this.computerMove = -1;
    }

    public ConnectFourViewModel(ConnectFourViewModel newGame)
    {
        this.gameID = newGame.gameID;
        this.board = newGame.board;

        this.playerMove = newGame.playerMove;
        this.computerMove = newGame.computerMove;
    }

    public void printBoard()
    {

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (board[i][j] == -1)
                {
                    System.out.print("|" + "O" + "|" );
                }
                else if (board[i][j] == 1)
                {
                    System.out.print("|" + "X" + "|");
                }
                else if (board[i][j] == 0)
                {
                    System.out.print("|" + " " + "|");
                }

            }
            System.out.println();
        }
    }

    public Integer getGameID() {
        return gameID;
    }

    public void setGameID(Integer gameID) {
        this.gameID = gameID;
    }

    public Integer getPlayerMove() {
        return playerMove;
    }

    public void setPlayerMove(Integer playerMove) {
        this.playerMove = playerMove;
    }

    public Integer getComputerMove() {
        return computerMove;
    }

    public void setComputerMove(Integer computerMove) {
        this.computerMove = computerMove;
    }

    public Integer[][] getBoard() {
        return board;
    }

    public void setBoard(Integer[][] board) {
        this.board = board;
    }
}
