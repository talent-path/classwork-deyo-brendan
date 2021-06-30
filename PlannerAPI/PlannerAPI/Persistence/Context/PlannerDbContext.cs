using PlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PlannerAPI.Persistence
{
    public class PlannerDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<Event> Events { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        public PlannerDbContext() : base()
        {

        }
    }
}
