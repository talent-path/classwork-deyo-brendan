using PlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Persistence.Repos
{
    public class EFEventRepo : IEventDao
    {
        PlannerDbContext _context;
        public EFEventRepo(PlannerDbContext context)
        {
            _context = context;
        }
        public int AddEvent(Event toAdd)
        {
            _context.Events.Add(toAdd);
            _context.SaveChanges();

            return toAdd.Id;
        }

        public void EditEvent(Event updated)
        {
            _context.Events.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public List<Activity> GetEventActivities(int id)
        {
            return _context.EventActivities
                .Where(e => e.EventId == id)
                .Include(e => e.Activity)
                .Select(e => new Activity(e.Activity)).ToList();
        }

        public List<Attendee> GetEventAttendees(int id)
        {
            return _context.EventAttendees
                .Where(e => e.EventId == id)
                .Include(e => e.Attendee)
                .Select(e => new Attendee(e.Attendee)).ToList();
        }

        public Organizer GetEventOrganizer(int? id)
        {
            int organizerId = _context.EventOrganizer
                .Where(e => e.EventId.Value == id.Value)
                .Select(e => e.OrganizerId.Value).SingleOrDefault();

            return _context.Organizers
                .Where(o => o.Id == organizerId).SingleOrDefault();
        }

        public Event GetEventById(int id)
        {
            return _context.Events.Find(id);
        }

        public Event GetEventByName(string name)
        {
            Event toReturn = _context.Events.Where(e => e.EventName.Replace(" ", "") == name.Replace(" ", "")).FirstOrDefault();
            return toReturn;
        }

        public void RemoveEvent(Event toRemove)
        {
            _context.Events.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}
