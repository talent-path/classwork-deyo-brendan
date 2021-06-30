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

        public Event GetEventById(int id)
        {
            return _context.Events.Find(id);
        }

        public void RemoveEvent(Event toRemove)
        {
            Event toDelete = new Event
            {
                Id = toRemove.Id
            };
            _context.Events.Attach(toRemove);
            _context.Events.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}
