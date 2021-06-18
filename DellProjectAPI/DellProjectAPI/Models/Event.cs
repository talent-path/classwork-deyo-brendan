using System;
using System.Collections.Generic;

namespace DellProjectAPI.Models
{
    public class Event
    {
        public Event()
        {
        }

        public DateTime Date { get; set; }
        public string EventName { get; set; }
        public int Id { get; set; }
        public List<Attendee> Attendees { get; set; }
        public int Duration { get; set; }

        public Event(Event that)
        {
            Date = that.Date;
            EventName = that.EventName;
            Id = that.Id;
            Attendees = that.Attendees;
            Duration = that.Duration;
        }

        public Event(int id, string name, DateTime date, List<Attendee> attendees, int duration)
        {
            Id = id;
            EventName = name;
            Date = date;
            Duration = duration;
            Attendees = attendees;
        }

    }
}
