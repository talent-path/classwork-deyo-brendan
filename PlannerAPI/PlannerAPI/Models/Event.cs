﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    [Table("Event")]
    public class Event
    {
        public Event()
        {
        }
        [Column("Activities")]
        public List<Activity> Activities { get; set; }

        [Required]
        public int OrganizerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string EventName { get; set; }

        [Column("Id")]
        public int Id { get; set; }

        [Column("Attendees")]
        public List<Attendee> Attendees { get; set; }

        [Required]
        public int Duration { get; set; }

        public Event(Event that)
        {
            Date = that.Date;
            EventName = that.EventName;
            Id = that.Id;
            Attendees = that.Attendees;
            Duration = that.Duration;
            OrganizerId = that.OrganizerId;
            Activities = that.Activities;
        }

        public Event(int id, string name, DateTime date, 
            List<Attendee> attendees, int duration, List<Activity> activities, int organizer)
        {
            Id = id;
            EventName = name;
            Date = date;
            Duration = duration;
            Attendees = attendees;
            Activities = activities;
            OrganizerId = organizer;
        }

    }
}