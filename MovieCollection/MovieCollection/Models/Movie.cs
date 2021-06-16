using System;
namespace MovieCollection.Models
{
    public class Movie
    {
        public int PublicationYear { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }

        public Movie()
        {
        }

        public Movie(Movie that)
        {
            PublicationYear = that.PublicationYear;
            Id = that.Id;
            Title = that.Title;
            Director = that.Director;
        }
    }
}
