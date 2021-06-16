using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HangManAPI.Models;



namespace HangManAPI.Persistence
{
    public class HangManInMemDao
    {
        static List<Game> _games = new List<Game>();
        


        public HangManInMemDao()
        {


        }



        public Game GetGameById(int id)
        {



            List<Game> games = GetAllGames();



            //if (int.TryParse(id, out parsed))
            //{
                Game toReturn = games.SingleOrDefault(h => h.Id == id);



                return new Game(toReturn);
            //}
            //else
            //    throw new NullReferenceException("This game does not exist ;-;");
        }



        public int AddGame(Game toAdd)
        {
            List<Game> games = GetAllGames();



            int idMax = 0;



            foreach (Game game in games)
            {
                int temp = game.Id;
               idMax = Math.Max(temp, idMax);
            }



            Game toReturn = new Game();
            toReturn.Id = idMax + 1;



            _games.Add(new Game(toReturn));



            return toReturn.Id;
        }



        public List<Game> GetAllGames()
        {
            List<Game> games = _games.Where(g => g != null).ToList();



            List<Game> toReturn = new List<Game>();



            foreach (Game game in games)
            {
                toReturn.Add(new Game(game));
            }


            return toReturn;
        }



        public void EditGame(Game update)
        {
            List<Game> games = GetAllGames();

            for (int i = 0; i < games.Count; i++)
            {
                Game game = games[i];
                if (game.Id == update.Id)
                {
                    game.Guesses = update.Guesses;
                    game.Id = update.Id;
                    game.IsDone = update.IsDone;
                    game.Progress = update.Progress;
                    game.SecretWord = update.SecretWord;
                    game.TurnsLeft = update.TurnsLeft;
                    _games[i] = game;
                }
            }
            int j = 0;
            
            //foreach (Game game in games.Where(g => g.Id == update.Id))
            //{
            //    game.Guesses = update.Guesses;
            //    game.Id = update.Id;
            //    game.IsDone = update.IsDone;
            //    game.Progress = update.Progress;
            //    game.SecretWord = update.SecretWord;
            //    game.TurnsLeft = update.TurnsLeft;
            //}
        }
    }
}