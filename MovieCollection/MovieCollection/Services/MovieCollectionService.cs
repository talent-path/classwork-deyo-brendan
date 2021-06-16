using System;
using System.Collections.Generic;
using MovieCollection.Models;
using System.Linq;

namespace MovieCollection.Services
{
    public class MovieCollectionService
    {
        static List<Movie> _movieList = new List<Movie>()
        {
            new Movie{Id = 1, Director = "George Martin", Title = "Game of Thrones", PublicationYear = 2000},
            new Movie{Id = 2, Director = "Ali Arsley", Title = "Hereditary", PublicationYear = 2012},
            new Movie{Id = 3, Director = "Tom Cruise", Title = "Mission Impossible: Fallout", PublicationYear = 2016},
            new Movie{Id = 4, Director = "Michael Bay", Title = "Transformers", PublicationYear = 2008},
            new Movie{Id = 5, Director = "Robert Downey Jr", Title = "Iron Man 3", PublicationYear = 2013},
        };

        public MovieCollectionService()
        {

        }

        public Movie GetById(int id)
        {
            return _movieList.Single(m => m.Id == id);
        }

        internal void EditMovie(Movie edited)
        {
            _movieList = _movieList.Select(m => m.Id == edited.Id ? edited : m).ToList();
        }

        internal IEnumerable<Movie> GetAllMovies()
        {
            return _movieList;
        }
    }
}
