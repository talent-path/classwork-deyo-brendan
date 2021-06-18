using System;
namespace DellProjectAPI.Models
{
    public class Activity
    {
        public Activity()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
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
