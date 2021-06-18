using System;
using System.Collections.Generic;
using DellProjectAPI.Models;
using DellProjectAPI.Persistence;

namespace DellProjectAPI.Services
{
    public class ProjectService
    {
        EventInMemDao _eventDao;
        ActivityInMemDao _activityDao;
        AttendeeInMemDao _attendeeDao;
        OrganizerInMemDao _organizerDao;
        ScheduleInMemDao _scheduleDao;

        public ProjectService()
        {
            _eventDao = new EventInMemDao();
            _activityDao = new ActivityInMemDao();
            _attendeeDao = new AttendeeInMemDao();
            _organizerDao = new OrganizerInMemDao();
            _scheduleDao = new ScheduleInMemDao();
        }

        public List<Event> GetAllEvents()
        {
            List<Event> toReturn = _eventDao.GetAllEvents();
            return toReturn;
        }

        public List<Attendee> GetAllAttendees()
        {
            List<Attendee> toReturn = _attendeeDao.GetAllEvents();
            return toReturn;
        }

        public List<Activity> GetAllActivites()
        {
            List<Activity> toReturn = _activityDao.GetAllActivites();
            return toReturn;
        }

        public List<Organizer> GetAllOrganizers()
        {
            List<Organizer> toReturn = _organizerDao.GetAllOrganizers();
            return toReturn;
        }

        public Schedule GetSchedule()
        {
            Schedule toReturn = _scheduleDao.GetSchedule();
            return toReturn;
        }
    }
}
