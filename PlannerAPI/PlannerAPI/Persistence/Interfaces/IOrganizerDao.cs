using PlannerAPI.Models;
using System.Collections.Generic;

namespace PlannerAPI.Persistence
{
    public interface IOrganizerDao
    {
        int AddOrganizer(Organizer toAdd);
        void EditOrganizer(Organizer updated);
        List<Organizer> GetAllOrganizers();
        Organizer GetOrganizerById(int id);
        void RemoveOrganizer(Organizer toRemove);
    }
}