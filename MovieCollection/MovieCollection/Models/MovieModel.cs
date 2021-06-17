using System;
namespace MovieCollection.Models
{
    public class MovieModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public MovieModel()
        {
        }

        public MovieModel(MovieModel that)
        {
            Id = that.Id;
            Title = that.Title;
            Director = that.Director;
            Year = that.Year; 
        }
    }
}
