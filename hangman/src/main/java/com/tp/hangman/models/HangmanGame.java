package com.tp.hangman.models;

import ch.qos.logback.core.util.InvocationGate;

import java.util.ArrayList;
import java.util.List;

public class HangmanGame {

    Integer gameId;
    String hiddenWord;
    Integer numberOfGuesses;
    Boolean gameOver;


    List<Character> guessedLetters;

    //constructor for a new game
    public HangmanGame( Integer gameId, String hiddenWord ){
        this.gameId = gameId;
        this.hiddenWord = hiddenWord;
        guessedLetters = new ArrayList<>();
        this.numberOfGuesses = this.hiddenWord.length() + 2;
        this.gameOver = false;
    }

    //constructor for an existing game (will have more use after we have databases)
    public HangmanGame(Integer gameId, String hiddenWord, List<Character> guessedLetters){
        this.gameId = gameId;
        this.hiddenWord = hiddenWord;
        this.guessedLetters = guessedLetters;
    }


    public Integer getGameId() {
        return gameId;
    }

    public String getHiddenWord() {
        return hiddenWord;
    }

    public List<Character> getGuessedLetters() {
        return guessedLetters;
    }

    public Boolean getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(boolean checkGame)
    {
        this.gameOver = checkGame;
    }
}
