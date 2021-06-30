using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        public Schedule()
        { 
            
        }

        public Schedule(Schedule that)
        {
            Id = that.Id;
            EventDate = that.EventDate;
            Events = that.Events;
        }

        public Schedule(int id, DateTime eventDate, List<Event> events)
        {
            Id = id;
            EventDate = eventDate;
            Events = events;
        }

        [Column("Id")]
        public int Id { get; set; }

        public DateTime EventDate { get; set; }

        public List<Event> Events { get; set; }

    }
}
