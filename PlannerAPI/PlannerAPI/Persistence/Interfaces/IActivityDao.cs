using PlannerAPI.Models;
using System.Collections.Generic;

namespace PlannerAPI.Persistence
{
    public interface IActivityDao
    {
        int AddActivity(Activity toAdd);
        void EditActivity(Activity update);
        Activity GetActivityById(int id);
        List<Activity> GetAllActivities();
        void RemoveActivity(Activity toRemove);
    }
}