using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.Models;
using MovieCollection.Services;

namespace MovieCollection.Controllers
{
    public class MovieCollectionController : Controller
    {

        MovieService _service = new MovieService();

        [HttpGet]
        public IActionResult EditMovieView(int? id)
        {
            if(id != null)
            {
                MovieModel model = _service.GetById(id.Value);
                return View(model); 
            }

            return this.BadRequest(); 
        }

        [HttpPost]
        public IActionResult EditMovieView(MovieModel updateMovie)
        {
            _service.EditMovie(updateMovie);
            return this.RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<MovieModel> toDisplay = _service.GetAllMovies();
            return View(toDisplay); 
        }

        [HttpPost]
        public IActionResult AddMovieView(MovieModel newMovie)
        {
             _service.AddMovie(newMovie);

            return this.RedirectToAction("Index"); 
        }

        

    }
}
