using DellProjectAPI.Models;
using System.Collections.Generic;

namespace DellProjectAPI.Persistence
{
    public interface IEventDao
    {
        void AddEvent(Event toAdd);
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        void RemoveEvent(Event toRemove);
    }
}