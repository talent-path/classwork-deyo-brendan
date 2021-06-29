using DellProjectAPI.Models;
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
        }

        public Activity GetActivityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetAllActivities()
        {
            throw new NotImplementedException();
        }

        public void RemoveActivity(Activity toRemove)
        {
            throw new NotImplementedException();
        }
    }
}
