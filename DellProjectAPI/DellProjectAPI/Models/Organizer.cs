using System;
namespace DellProjectAPI.Models
{
    public class Organizer
    {
        public Organizer()
        {
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public Event OrganizedEvent { get; set; }

        public Organizer(Organizer that)
        {
            Name = that.Name;
            Id = that.Id;
            OrganizedEvent = that.OrganizedEvent;
        }
    }
}
