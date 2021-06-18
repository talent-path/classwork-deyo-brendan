using System;
namespace DellProjectAPI.Models
{
    public class Attendee
    {
        public Attendee()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Attendee(Attendee that)
        {
            Id = that.Id;
            Name = that.Name;
        }

    }
}
