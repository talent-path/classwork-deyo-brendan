package com.tp.connectfour.persistence;

import com.tp.connectfour.models.ConnectFourViewModel;

import java.util.List;

public interface ConnectFourDao {


    ConnectFourViewModel getGameByID(Integer gameID);

    List<ConnectFourViewModel> getAllGames();

    void clearBoard(ConnectFourViewModel game);

    ConnectFourViewModel startGame();

    void deleteGame(Integer gameId) throws InvalidGameIdException;


}
