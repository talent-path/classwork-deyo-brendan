using System;
using System.Collections.Generic;
using PlannerAPI.Models;
using PlannerAPI.Persistence;
using PlannerAPI.Persistence.Repos;
using PlannerAPI.Exceptions;

namespace PlannerAPI.Services
{
    public class ProjectService
    {
        EFEventRepo _eventRepo;
        EFActivityRepo _activityRepo;
        EFAttendeeRepo _attendeeRepo;
        EFOrganizerRepo _organizerRepo;
        //ScheduleInMemDao _scheduleDao;

        public ProjectService(PlannerDbContext context)
        {
            _eventRepo = new EFEventRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _activityRepo = new EFActivityRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _attendeeRepo = new EFAttendeeRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _organizerRepo = new EFOrganizerRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            //_scheduleDao = new ScheduleInMemDao();
        }

        // GET ALL FOR OBJECTS 
        public List<Event> GetAllEvents()
        {
            List<Event> toReturn = _eventRepo.GetAllEvents();

            if (toReturn == null)
                throw new EmptyListException("No events were found");
            else
                return toReturn;
        }

        public List<Attendee> GetAllAttendees()
        {
            List<Attendee> toReturn = _attendeeRepo.GetAllAttendees();

            if (toReturn == null)
                throw new EmptyListException("No attendees were found");
            else
                return toReturn;
        }

        public List<Activity> GetAllActivites()
        {
            List<Activity> toReturn = _activityRepo.GetAllActivities();

            if (toReturn == null)
                throw new EmptyListException("No activities were found");
            else
                return toReturn;
        }

        public List<Organizer> GetAllOrganizers()
        {
            List<Organizer> toReturn = _organizerRepo.GetAllOrganizers();

            if (toReturn == null)
                throw new EmptyListException("No organizers were found");
            else
                return toReturn;
        }

        //public Schedule GetSchedule()
        //{
        //    Schedule toReturn = _scheduleDao.GetSchedule();
        //    return toReturn;
        //}

        // ADD OBJECTS

        public void AddEvent(Event toAdd)
        {
            if (toAdd == null)
                throw new NullObjectException("This event is null or has null properties");
            else
                _eventRepo.AddEvent(toAdd);
        }

        public void AddAttendee(Attendee toAdd)
        {
            if (toAdd == null)
                throw new NullObjectException("This attendee is null or has null properties");
            else
                _attendeeRepo.AddAttendee(toAdd);
        }

        public void AddOrganizer(Organizer toAdd)
        {
            if (toAdd == null)
                throw new NullObjectException("This organizer is null or has null properties");
            else
                _organizerRepo.AddOrganizer(toAdd);
        }

        public void AddActivity(Activity toAdd)
        {
            if (toAdd == null)
                throw new NullObjectException("This activity is null or has null properties");
            else
                _activityRepo.AddActivity(toAdd);
        }

        // REMOVE OBJECTS

        public void RemoveActivity(Activity toRemove)
        {
            if (toRemove.Id <= 0)
                throw new InvalidIdException("Can't remove activity with this ID");
            else
                _activityRepo.RemoveActivity(toRemove);
        }

        public void RemoveEvent(Event toRemove)
        {
            if (toRemove.Id <= 0)
                throw new InvalidIdException("Can't remove event with this ID");
            else
                _eventRepo.RemoveEvent(toRemove);
        }

        public void RemoveOrganizer(Organizer toRemove)
        {
            if (toRemove.Id <= 0)
                throw new InvalidIdException("Can't remove organizer with this ID");
            else
                _organizerRepo.RemoveOrganizer(toRemove);
        }

        public void RemoveAttendee(Attendee toRemove)
        {
            if (toRemove.Id <= 0)
                throw new InvalidIdException("Can't remove attendee with this ID");
            else
                _attendeeRepo.RemoveAttendee(toRemove);
        }

        // EDIT OBJECTS

        public void EditAttendee(Attendee updated)
        {
            if (updated == null)
                throw new NullObjectException("This attendee is null or has null properties");
            else
                _attendeeRepo.EditAttendee(updated);
        }

        public void EditEvent(Event updated)
        {
            if (updated == null)
                throw new NullObjectException("This event is null or has null properties");
            else
                _eventRepo.EditEvent(updated);
        }

        public void EditOrganizer(Organizer updated)
        {
            if (updated == null)
                throw new NullObjectException("This organizer is null or has null properties");
            else
                _organizerRepo.EditOrganizer(updated);
        }

        public void EditActivity(Activity updated)
        {
            if (updated == null)
                throw new NullObjectException("This activity is null or has null properties");
            else
                _activityRepo.EditActivity(updated);
        }

        // GET BY OBJECT ID'S

        public Activity GetActivityById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("This ID input is invalid");
            else
                return _activityRepo.GetActivityById(id);
        }

        public Event GetEventById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("This ID input is invalid");
            else
                return _eventRepo.GetEventById(id);
        }

        public Organizer GetOrganizerById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("This ID input is invalid");
            else
                return _organizerRepo.GetOrganizerById(id);
        }

        public Attendee GetAttendeeById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("This ID input is invalid");
            else
                return _attendeeRepo.GetAttendeeById(id);
        }

    }
}
