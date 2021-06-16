using System;
using System.Collections.Generic;

namespace HangManAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int TurnsLeft { get; set; }
        public string SecretWord { get; set; }
        public bool IsDone { get; set; }
        public char[] Progress { get; set; }
        public List<char> Guesses { get; set; }

        public Game()
        {
            Guesses = new List<char>();
            SecretWord = "special";
            TurnsLeft = 10;
            Progress = new char[SecretWord.Length];
            for (int i = 0; i < Progress.Length; i++)
            {
                Progress[i] = '-';
            }
        }

        public Game(Game game)
        {
            Id = game.Id;
            TurnsLeft = game.TurnsLeft;
            SecretWord = game.SecretWord;
            IsDone = game.IsDone;
            Progress = game.Progress;
            Guesses = new List<char>(game.Guesses);
        }
    }
}
    