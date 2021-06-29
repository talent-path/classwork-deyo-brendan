using DellProjectAPI.Models;
using System.Collections.Generic;

namespace DellProjectAPI.Persistence
{
    public interface IAttendeeDao
    {
        void AddAttendee(Attendee toAdd);
        void EditAttendee(Attendee updated);
        List<Attendee> GetAllAttendees();
        Attendee GetAttendeeById(int id);
        void RemoveAttendee(Attendee toRemove);
    }
}