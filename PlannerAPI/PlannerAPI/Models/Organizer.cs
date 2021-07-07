using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    [Table("Organizer")]
    public class Organizer
    {
        public Organizer()
        {
        }

        [Required]
        public string Name { get; set; }
        [Column("Id")]
        public int Id { get; set; }
        [Column("OrganizedEvents")]
        public List<Event> OrganizedEvents { get; set; } = new List<Event>();

        [Required]
        [MaxLength(75)]
        public string Email { get; set; }

        public Organizer(Organizer that)
        {
            Name = that.Name;
            Id = that.Id;
            OrganizedEvents = that.OrganizedEvents;
        }

        public Organizer(string name, int id, List<Event> theseEvents)
        {
            Name = name;
            Id = id;
            OrganizedEvents = theseEvents;
        }
    }
}
