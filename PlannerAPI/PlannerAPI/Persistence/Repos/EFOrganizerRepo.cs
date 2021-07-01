using PlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Persistence.Repos
{
    public class EFOrganizerRepo : IOrganizerDao
    {
        PlannerDbContext _context;

        public EFOrganizerRepo(PlannerDbContext context)
        {
            _context = context;
        }

        public int AddOrganizer(Organizer toAdd)
        {
            _context.Organizers.Add(toAdd);
            _context.SaveChanges();

            return toAdd.Id;
        }

        public void EditOrganizer(Organizer updated)
        {
            _context.Organizers.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Organizer> GetAllOrganizers()
        {
            return _context.Organizers.ToList();
        }

        public Organizer GetOrganizerById(int id)
        {
            return _context.Organizers.Find(id);
        }

        public void RemoveOrganizer(Organizer toRemove)
        {
            _context.Organizers.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}
