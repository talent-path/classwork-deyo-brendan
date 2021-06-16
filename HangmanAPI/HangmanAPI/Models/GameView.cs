using System;
using System.Collections.Generic;

namespace HangManAPI.Models
{
    public class GameView
    {
        public int _Id { get; set; }
        public int _TurnsLeft { get; set; }
        public string _SecretWord { get; set; }
        public bool _IsDone { get; set; }
        public char[] _Progress { get; set; }
        public List<char> _Guesses { get; set; }

        public GameView(Game game)
        {
            _Id = game.Id;
            _TurnsLeft = game.TurnsLeft;
            _SecretWord = game.SecretWord;
            _IsDone = game.IsDone;
            _Progress = game.Progress;
            _Guesses = game.Guesses;
        }
    }
}
