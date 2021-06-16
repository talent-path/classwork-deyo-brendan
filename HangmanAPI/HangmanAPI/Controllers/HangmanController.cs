using System;
using Microsoft.AspNetCore.Mvc;
using HangManAPI.Models;
using System.Collections.Generic;
using System.Linq;
using HangManAPI.Persistence;
using HangManAPI.Services;


namespace HangManAPI.Controllers
{



    [ApiController]
    [Route("/api")]
    public class HangmanController : ControllerBase
    {
        HangManService serv;


        public HangmanController()
        {

            serv = new HangManService();

        }



        [HttpPost("begin")]
        public int CreateNewHangmanGame()
        {
            return serv.Begin();
        }



        [HttpGet("games")]
        public List<Game> GetAllHangmanGames()
        {
            return serv.GetGames();
        }



        [HttpGet("game/{id}")]
        public Game GetHangmanGameById(int id)
        {
            return serv.GetGameById(id);
        }



        [HttpPut("game")]
        public ActionResult EnterGuess(Guess currentGame)
        {
            serv.MakeGuess(currentGame);
            return this.LocalRedirect("/api/game/" + currentGame.Id);
        }
    }
}