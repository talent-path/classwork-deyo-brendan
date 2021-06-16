using System;
using System.Collections.Generic;
using HangManAPI.Persistence;
using HangManAPI.Models;
namespace HangManAPI.Services
{
    public class HangManService
    {

        HangManInMemDao dao;

        public HangManService()
        {
            dao = new HangManInMemDao();
        }

        public int Begin()
        {
            Game game = new Game();
            return dao.AddGame(game);
        }

        public List<Game> GetGames()
        {
            List<Game> games = dao.GetAllGames();
            for (int i = 0; i < games.Count; i++)
            {
                Game game = games[i];
                game.IsDone = this.IsDone(game);
                if (!game.IsDone)
                {
                    HideWord(game);
                }
            }
            return games;
        }

        public Game GetGameById(int id)
        {
            Game game = dao.GetGameById(id);
            if (!game.IsDone) HideWord(game);
            game.IsDone = this.IsDone(game);
            return game;
        }

        public void MakeGuess(Guess guess)
        {
            Game game = dao.GetGameById(guess.Id);
            game.Guesses.Add(guess.Letter);
            game.TurnsLeft--;
            game.IsDone = this.IsDone(game);
            this.ConstructProgress(game);
            dao.EditGame(game);
        }

        private void ConstructProgress(Game game)
        {
            for (int i = 0; i < game.Guesses.Count; i++)
            {
                char letter = game.Guesses[i];
                for (int j = 0; j < game.SecretWord.Length; j++)
                {
                    if (letter==game.SecretWord[j])
                    {
                        game.Progress[j] = letter;
                    }
                }
            }
        }

        private bool IsDone(Game game)
        {
            if (game.TurnsLeft <= 0) return true;
            for (int i = 0;i<game.Progress.Length;i++)
            {
                char sym = game.Progress[i];
                if (sym == '-') return false;
            }
            return true;
        }

        private void HideWord(Game game)
        {
            string word = game.SecretWord;
            string hidden = "";
            for (int i = 0; i < word.Length; i++)
            {
                hidden += "- ";
            }
            game.SecretWord = hidden;
        }
    }
}
