using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DellProjectAPI.Models
{
    [Table("Activity")]
    public class Activity
    {
        public Activity()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        public Activity(Activity that)
        {
            Duration = that.Duration;
            Id = that.Id;
            Name = that.Name;

        }

        public Activity(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }
    }
}
