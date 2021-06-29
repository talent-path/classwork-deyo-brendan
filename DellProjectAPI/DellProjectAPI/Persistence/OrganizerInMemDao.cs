//using System;
//using System.Linq;
//using System.Collections.Generic;
//using DellProjectAPI.Models;

//namespace DellProjectAPI.Persistence
//{
//    public class OrganizerInMemDao : IOrganizerDao
//    {
//        //    List<Organizer> _organizers = new List<Organizer>();
//        //    List<Event> _eventList = new List<Event>();

//        //    public OrganizerInMemDao()
//        //    {
//        //        _eventList.Add(new Event(1, "Brendan's Party", new DateTime(2021, 6, 28), _attendees, 60));
//        //        _eventList.Add(new Event(2, "John's Party", new DateTime(2020, 5, 06), _attendees, 30));
//        //        _eventList.Add(new Event(3, "Quinton's Party", new DateTime(1997, 2, 19), _attendees, 85));
//        //        _eventList.Add(new Event(4, "Renee's Party", new DateTime(1956, 8, 20), _attendees, 90));
//        //        _eventList.Add(new Event(5, "Jimmy's Party", new DateTime(1996, 2, 20), _attendees, 80));

//        //        _organizers.Add(new Organizer("Jimmy", 1, _eventList[0]));
//        //        _organizers.Add(new Organizer("Steve", 2, _eventList[1]));
//        //        _organizers.Add(new Organizer("John", 3, _eventList[2]));
//        //        _organizers.Add(new Organizer("Bob", 4, _eventList[3]));
//        //        _organizers.Add(new Organizer("Mario", 5, _eventList[4]));
//        //    }

//        //    public List<Organizer> GetAllOrganizers()
//        //    {
//        //        return _organizers.Where(o => o != null).ToList();
//        //    }

//        //    public void RemoveOrganizer(Organizer toRemove)
//        //    {
//        //        _organizers = _organizers.Where(o => o.Id != toRemove.Id).ToList();
//        //    }

//        //    public void AddOrganizer(Organizer toAdd)
//        //    {
//        //        if (toAdd != null)
//        //            _organizers.Add(toAdd);
//        //        else
//        //            throw new NullReferenceException("Organizer is null");
//        //    }

//        //    public void EditOrganizer(Organizer updated)
//        //    {
//        //        List<Organizer> organizers = GetAllOrganizers();

//        //        for (int i = 0; i < organizers.Count; i++)
//        //        {
//        //            Organizer organizer = organizers[i];
//        //            if (organizer.Id == updated.Id)
//        //            {
//        //                organizer.Id = updated.Id;
//        //                organizer.Name = updated.Name;
//        //                organizer.OrganizedEvent = updated.OrganizedEvent;
//        //                _organizers[i] = organizer;
//        //            }
//        //        }
//        //    }

//        //    public Organizer GetOrganizerById(int id)
//        //    {
//        //        List<Organizer> organizers = GetAllOrganizers();

//        //        Organizer toReturn = organizers.Where(o => o.Id == id).SingleOrDefault();

//        //        if (toReturn == null)
//        //            throw new NullReferenceException("Organizer is null");
//        //        else
//        //            return toReturn;
//        //    }
//        //}
//    }
//}
