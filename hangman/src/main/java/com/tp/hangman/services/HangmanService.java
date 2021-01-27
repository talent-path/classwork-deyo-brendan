package com.tp.hangman.services;

import com.tp.hangman.models.HangmanGame;
import com.tp.hangman.models.HangmanViewModel;
import com.tp.hangman.persistence.HangmanDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

//handles the logic for the game
@Component
public class HangmanService {

    @Autowired
    HangmanDao dao;

    public HangmanViewModel getGameById(Integer gameId) {
        HangmanGame game = dao.getGameById(gameId);
        return convertModel(game);
    }


    public HangmanViewModel makeGuess(Integer gameId, String guess) {

        HangmanGame game = dao.getGameById(gameId);

        int count = 0;

        int remainingGuesses = game.getHiddenWord().length() + 2;

        if (!game.getGameOver()) {

//            for (int i = 0; i < game.getHiddenWord().length(); i++) {
//                boolean foundLetter = false;
//                for (int j = 0; j < game.getGuessedLetters().size(); j++) {
//                    if (game.getHiddenWord().charAt(i) == game.getGuessedLetters().get(j)) {
//                        foundLetter = true;
//                    }
//                }
//                if (foundLetter) {
//                    count = 0;
//                } else {
//                    count++;
//                }
//            }

            if (guess.length() != 1) {
                throw new NullPointerException("Guess cannot be more than 1");
            }


            if (gameId == null) {
                //TODO: make and throw a custom exception here
                throw new NullPointerException("Game ID must exist.");
            }


            //we'll assume here that the dao gives us back a null
            //if there's no matching game
            if (game == null) {
                return null;
            }

            game.getGuessedLetters().add(guess.charAt(0));

            System.out.println();
            System.out.println("# of Guesses: " + game.getGuessedLetters().size());
            System.out.println("# Remaining: " + (remainingGuesses - game.getGuessedLetters().size()));

            if (game.getGuessedLetters().size() == game.getHiddenWord().length() + 2) {
                game.setGameOver(true);
                System.out.println("GAME OVER!");
            }
        }

        return convertModel(game);
    }


    private HangmanViewModel convertModel(HangmanGame game) {
        //TODO: generate the string with all the letters hidden that have not been guessed
        //and build the view model object (using the setters)

        List<Character> newList = game.getGuessedLetters();

        String hiddenWord = game.getHiddenWord();

        int count = 0;

        String newStr = "";

        for (int i = 0; i < hiddenWord.length(); i++) {
            boolean foundLetter = false;
            for (int j = 0; j < newList.size(); j++) {
                if (hiddenWord.charAt(i) == newList.get(j)) {
                    foundLetter = true;
                }
            }
            if (foundLetter) {
                newStr += hiddenWord.charAt(i);
            } else {
                count++;
                newStr += "_";
            }
        }

        HangmanViewModel newHangman = new HangmanViewModel();

        newHangman.setPartialWord(newStr);

        newHangman.setGuessedLetters(newList);

        return newHangman;
    }
}
