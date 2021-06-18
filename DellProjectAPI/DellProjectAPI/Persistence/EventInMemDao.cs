using System;
using System.Collections.Generic;
using DellProjectAPI.Models;
using System.Linq;

namespace DellProjectAPI.Persistence
{
    public class EventInMemDao
    {

        List<Event> _eventList = new List<Event>();
        List<Attendee> _attendees = new List<Attendee>();

        public EventInMemDao()
        {
            _attendees.Add(new Attendee(1, "John"));
            _attendees.Add(new Attendee(2, "David"));
            _attendees.Add(new Attendee(3, "Jimmu"));
            _attendees.Add(new Attendee(4, "Stephen"));
            _attendees.Add(new Attendee(5, "Walter"));

            _eventList.Add(new Event(1, "Brendan's Party", new DateTime(2021, 6, 28), _attendees, 60));
            _eventList.Add(new Event(2, "John's Party", new DateTime(2020, 5, 06), _attendees, 30));
            _eventList.Add(new Event(3, "Quinton's Party", new DateTime(1997, 2, 19), _attendees, 85));
            _eventList.Add(new Event(4, "Renee's Party", new DateTime(1956, 8, 20), _attendees, 90));
            _eventList.Add(new Event(5, "Jimmy's Party", new DateTime(1996, 2, 20), _attendees, 80));
        }

        public Event GetEventById(int id)
        {
            List<Event> events = GetAllEvents();

            Event toReturn = events.Where(e => e.Id == id).SingleOrDefault();

            if (toReturn == null)
                throw new NullReferenceException("Event does not exist");

            return toReturn;
        }

        public void RemoveEvent(Event toRemove)
        {
            _eventList = _eventList.Where(e => e.Id != toRemove.Id).ToList();
        }

        public List<Event> GetAllEvents()
        {
            return _eventList.Where(e => e != null).ToList();
        }

        public void AddEvent(Event toAdd)
        {
            if (toAdd == null)
                throw new NullReferenceException("Event is null");
            else
                _eventList.Add(toAdd);
        }
    }
}
