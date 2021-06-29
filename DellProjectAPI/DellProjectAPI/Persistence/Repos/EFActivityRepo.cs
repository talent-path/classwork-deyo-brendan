using DellProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellProjectAPI.Persistence.Repos
{
    public class EFActivityRepo : IActivityDao
    {
        PlannerDbContext _context;
        public EFActivityRepo(PlannerDbContext context) 
        {
            _context = context;
        }

        public void AddActivity(Activity toAdd)
        {
            _context.Activities.Add(toAdd);
            _context.SaveChanges();
        }

        public void EditActivity(Activity update)
        {
            _context.Activities.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Activity GetActivityById(int id)
        {
            Activity toReturn = _context.Activities.Find(id);
            return toReturn;
        }

        public List<Activity> GetAllActivities()
        {
            List<Activity> allActivities = _context.Activities.ToList();
            return allActivities;
        }

        public void RemoveActivity(Activity toRemove)
        {
            Activity toDelete = new Activity
            {
                Id = toRemove.Id
            };
            _context.Activities.Attach(toDelete);
            _context.Activities.Remove(toDelete);
            _context.SaveChanges();

        }
    }
}
