package com.tp.connectfour.services;


import com.tp.connectfour.RNG;
import com.tp.connectfour.models.ConnectFourViewModel;
import com.tp.connectfour.persistence.ConnectFourDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class ConnectFourService {

    @Autowired
    ConnectFourDao dao;

    public ConnectFourViewModel startGame() {
        return dao.startGame();
    }

    public List<ConnectFourViewModel> getAllGames() {
        return dao.getAllGames();
    }

    public ConnectFourViewModel getGameByID(Integer gameID)
    {
        return dao.getGameByID(gameID);
    }

    public void deleteGame(Integer gameID)
    {
        dao.deleteGame(gameID);
    }

    public void clearBoard(ConnectFourViewModel game)
    {
        dao.clearBoard(game);
    }

    public ConnectFourViewModel makeMove(Integer gameID, Integer columnMove) {
        if (columnMove == null) {
            // exception
        }
        if (gameID == null) {
            // exception
        }
        if (columnMove < 1 || columnMove > 7) {
            // exception
        }

        ConnectFourViewModel game = dao.getGameByID(gameID);

        if (game == null) {
            // exception
        }

        int rowMove = 6;

        for (int i = 0; i < 5; i++) {
            if (i < rowMove && game.getBoard()[i][columnMove] == 0) {
                rowMove = i;
                break;
            }
        }

        if (rowMove == 6) {
            // exception
        }

        game.getBoard()[rowMove][columnMove - 1] = game.getPlayerMove();

        int num = checkWinner(game.getBoard());

        if (num > -2)
        {
           if (num == 1)
           {
               System.out.println("--- *** PLAYER WINS *** ---");
           }
           else if (num == -1)
           {
               System.out.println("--- *** COMPUTER WINS *** ---");
           }
           else if (num == 0)
           {
               System.out.println("--- *** DRAW *** ---");
           }

        }

        computerMove(game);

        checkWinner(game.getBoard());

        return game;
    }

    public ConnectFourViewModel computerMove(ConnectFourViewModel game) {

        ConnectFourViewModel copyGame = game;

        int compMove = RNG.randInt(0, 6);

        int rowMove = 6;

        while (rowMove > 5) {
            for (int i = 0; i < 5; i++) {
                if (i < rowMove && copyGame.getBoard()[i][compMove] == 0) {
                    rowMove = i;
                    break;
                }
            }
            compMove = RNG.randInt(0, 6);
        }

        copyGame.getBoard()[rowMove][compMove - 1] = copyGame.getComputerMove();

        return copyGame;

    }

    public Integer checkWinner(Integer[][] board)
    {
        int gameState = -2;
        if (checkDraw(board))
            return 0;
        else if (checkColumn(board) > gameState)
        {
            return checkColumn(board);
        }
        else if (checkRow(board) > gameState)
        {
            return checkRow(board);
        }
        else if (checkDiagonal(board) > gameState)
        {
            return checkDiagonal(board);
        }
        else
            return gameState;

    }

    public boolean checkDraw(Integer[][] board) {

        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 7; j++) {
                if (board[i][j] == 0) {
                    return false;
                }
            }
        }

        return true;

    }

    public Integer checkRow(Integer[][] board) {

        if (checkDraw(board))
            return 0;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i][j] == board[i][j + 1] && board[i][j] == board[i][j + 2]
                        && board[i][j] == board[i][j + 3]) {
                    return board[i][j];
                }
            }
        }

        return -2;

    }

    public Integer checkColumn(Integer[][] board) {

        if (checkDraw(board))
            return 0;

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 6; j++) {
                if (board[i][j] == board[i + 1][j] && board[i][j] == board[i + 2][j]
                        && board[i][j] == board[i + 3][j]) {
                    return board[i][j];
                }
            }
        }

        return -2;

    }

    public Integer checkDiagonal(Integer[][] board) {

        if (checkDraw(board))
            return 0;

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i][j] == board[i + 1][j + 1] && board[i][j] == board[i + 2][j + 2]
                        && board[i][j] == board[i + 3][j + 3])
                {
                    return board[i][j];
                }
            }
        }

        for (int i = 3; i < 7; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i][j] == board[i - 1][j - 1] && board[i][j] == board[i - 2][j - 2]
                        && board[i][j] == board[i - 2][j - 2]) {
                    return board[i][j];
                }
            }
        }

        return -2;
    }

}
