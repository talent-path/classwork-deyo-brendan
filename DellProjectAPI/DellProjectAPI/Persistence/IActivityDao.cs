using DellProjectAPI.Models;
using System.Collections.Generic;

namespace DellProjectAPI.Persistence
{
    public interface IActivityDao
    {
        void AddActivity(Activity toAdd);
        void EditActivity(Activity update);
        Activity GetActivityById(int id);
        List<Activity> GetAllActivities();
        void RemoveActivity(Activity toRemove);
    }
}