using System;
using System.Collections.Generic;
using PlannerAPI.Models;
using System.Linq;

namespace PlannerAPI.Persistence
{
    public class EventInMemDao : IEventDao
    {

        List<Event> _eventList = new List<Event>();
        List<Attendee> _attendees = new List<Attendee>();
        List<Activity> _activityList = new List<Activity>();
        List<Organizer> _organizers = new List<Organizer>();


        public EventInMemDao()
        {
            _organizers.Add(new Organizer("Jimmy", 1, _eventList));
            _organizers.Add(new Organizer("Steve", 2, _eventList));
            _organizers.Add(new Organizer("John", 3, _eventList));
            _organizers.Add(new Organizer("Bob", 4, _eventList));
            _organizers.Add(new Organizer("Mario", 5, _eventList));

            _activityList.Add(new Activity(1, "Bowling", 50));
            _activityList.Add(new Activity(2, "Running", 20));
            _activityList.Add(new Activity(3, "Jogging", 40));
            _activityList.Add(new Activity(4, "Lifting", 90));
            _activityList.Add(new Activity(5, "Swimming", 50));

            _attendees.Add(new Attendee(1, "John"));
            _attendees.Add(new Attendee(2, "David"));
            _attendees.Add(new Attendee(3, "Jimmu"));
            _attendees.Add(new Attendee(4, "Stephen"));
            _attendees.Add(new Attendee(5, "Walter"));

            _eventList.Add(new Event(1, "Brendan's Party", 
                new DateTime(2021, 6, 28), _attendees, 60, _activityList, _organizers[0].Id));
            _eventList.Add(new Event(2, "John's Party", 
                new DateTime(2020, 5, 06), _attendees, 30, _activityList, _organizers[1].Id));
            _eventList.Add(new Event(3, "Quinton's Party", 
                new DateTime(1997, 2, 19), _attendees, 85, _activityList, _organizers[2].Id));
            _eventList.Add(new Event(4, "Renee's Party", 
                new DateTime(1956, 8, 20), _attendees, 90, _activityList, _organizers[3].Id));
            _eventList.Add(new Event(5, "Jimmy's Party", 
                new DateTime(1996, 2, 20), _attendees, 80, _activityList, _organizers[3].Id));
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

        public int AddEvent(Event toAdd)
        {
            if (toAdd == null)
                throw new NullReferenceException("Event is null");
            else
            {
                _eventList.Add(toAdd);
                return toAdd.Id;
            }
        }

        public void EditEvent(Event updated)
        {
            throw new NotImplementedException();
        }

        public Event GetEventByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
