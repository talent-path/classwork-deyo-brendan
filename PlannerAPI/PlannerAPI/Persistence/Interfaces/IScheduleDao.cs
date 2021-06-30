using PlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Persistence.Interfaces
{
    public interface IScheduleDao
    {
        int AddSchedule(Schedule toAdd);

        void EditSchedule(Schedule updated);

        List<Schedule> GetAllSchedules();

        Schedule GetScheduleById(int id);

        void RemoveSchedule(Schedule toDelete);
    }
}
