using System;
using System.Collections.Generic;
using System.Linq;
using MovieCollection.Models;

namespace MovieCollection.Services
{
    public class MovieService
    {

        static List<MovieModel> _movies = new List<MovieModel>()
        {
            new MovieModel{Id = 1, Title = "All for Her", Director = "Herbert Brenon", Year =1912 },
            new MovieModel{Id = 2, Title = "Kitty's Knight", Director = "Wallace Beery", Year =1913 },
            new MovieModel{Id = 3, Title = "Twenty Minutes of Love", Director = "Charlie Chaplin", Year =1914 },
            new MovieModel{Id = 4, Title = "In the Diplomatic Service", Director = "Francis X. Bushman", Year = 1916 },
            new MovieModel{Id = 5, Title = "My Favorite Year", Director = "Richard Benjamin", Year = 1982 }

        };

        public MovieModel GetById(int id)
        {
            return _movies.Single(m => m.Id == id); 
        }

        internal void EditMovie(MovieModel updateMovie)
        {
            _movies=  _movies.Select(m => m.Id == updateMovie.Id ? updateMovie : m).ToList(); 
        }

        internal IEnumerable<MovieModel> GetAllMovies()
        {
            return _movies; 
        }

        internal void AddMovie(MovieModel newMovie)
        {
            newMovie.Id = _movies.Count + 1;
            
                _movies.Add(newMovie);

            
        }
    }
}
