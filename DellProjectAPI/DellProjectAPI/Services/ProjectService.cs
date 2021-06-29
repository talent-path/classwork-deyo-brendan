using System;
using System.Collections.Generic;
using DellProjectAPI.Models;
using DellProjectAPI.Persistence;

namespace DellProjectAPI.Services
{
    public class ProjectService
    {
        IEventDao _eventDao;
        IActivityDao _activityDao;
        IAttendeeDao _attendeeDao;
        IOrganizerDao _organizerDao;
        //ScheduleInMemDao _scheduleDao;

        public ProjectService(IEventDao eventDao, IActivityDao activityDao, 
            IAttendeeDao attendeeDao, IOrganizerDao organizerDao) 
        {
            _eventDao = eventDao;
            _activityDao = activityDao;
            _attendeeDao = attendeeDao;
            _organizerDao = organizerDao;
            //_scheduleDao = new ScheduleInMemDao();
        }

        public List<Event> GetAllEvents()
        {
            List<Event> toReturn = _eventDao.GetAllEvents();
            return toReturn;
        }

        public List<Attendee> GetAllAttendees()
        {
            List<Attendee> toReturn = _attendeeDao.GetAllAttendees();
            return toReturn;
        }

        public List<Activity> GetAllActivites()
        {
            List<Activity> toReturn = _activityDao.GetAllActivities();
            return toReturn;
        }

        public List<Organizer> GetAllOrganizers()
        {
            List<Organizer> toReturn = _organizerDao.GetAllOrganizers();
            return toReturn;
        }

        //public Schedule GetSchedule()
        //{
        //    Schedule toReturn = _scheduleDao.GetSchedule();
        //    return toReturn;
        //}

        public void AddEvent(Event toAdd)
        {
           
        }

        public void AddAttendee(Attendee toAdd)
        {

        }

        public void AddOrganizer()
        {

        }

        public void AddActivity()
        {

        }

        public void RemoveActivity()
        {

        }

        public void RemoveEvent()
        {

        }

        public void RemoveOrganizer()
        {

        }

        public void RemoveAttendee()
        {

        }

        public void EditAttendee()
        {

        }

        public void EditEvent()
        {

        }

        public void EditOrganizer()
        {

        }

        public void EditActivity()
        {

        }

        //public Event GetEventById(int id)
        //{

        //}

        //public Organizer GetOrganizerById(int id)
        //{

        //}

        //public Attendee GetAttendeeById(int id)
        //{

        //}

        //public Activity GetActivityById(int id)
        //{

        //}
    }
}
