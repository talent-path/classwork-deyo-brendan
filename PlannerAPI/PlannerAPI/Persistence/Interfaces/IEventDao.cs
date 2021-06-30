using PlannerAPI.Models;
using System.Collections.Generic;

namespace PlannerAPI.Persistence
{
    public interface IEventDao
    {
        int AddEvent(Event toAdd);
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        void RemoveEvent(Event toRemove);
        void EditEvent(Event updated);
    }
}