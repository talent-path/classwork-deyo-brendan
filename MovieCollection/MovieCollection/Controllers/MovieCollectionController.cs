using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.Models;
using MovieCollection.Services;

namespace MovieCollection.Controllers
{
    public class MovieCollectionController : Controller
    {
        public MovieCollectionController()
        {

        }

        MovieCollectionService _service = new MovieCollectionService();

        [HttpGet]
        public IActionResult EditMovieView(int? id)
        {
            if (id != null)
            {
                Movie movie = _service.GetById(id.Value);
                return View(movie);
            }

            return this.BadRequest();
        }

        [HttpPost]
        public IActionResult EditMovieView(Movie movie)
        {
            _service.EditMovie(movie);
            return this.RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            IEnumerable<Movie> toDisplay = _service.GetAllMovies();

            return View(toDisplay);
        }

    }
}
