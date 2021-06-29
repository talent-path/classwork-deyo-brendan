using DellProjectAPI.Models;
using System.Collections.Generic;

namespace DellProjectAPI.Persistence
{
    public interface IOrganizerDao
    {
        void AddOrganizer(Organizer toAdd);
        void EditOrganizer(Organizer updated);
        List<Organizer> GetAllOrganizers();
        Organizer GetOrganizerById(int id);
        void RemoveOrganizer(Organizer toRemove);
    }
}