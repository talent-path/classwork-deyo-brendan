using System;
using System.Collections.Generic;
using PlannerAPI.Models;
using PlannerAPI.Persistence;
using PlannerAPI.Persistence.Repos;
using PlannerAPI.Exceptions;

namespace PlannerAPI.Services
{
    public class PlannerService
    {
        EFEventRepo _eventRepo;
        EFActivityRepo _activityRepo;
        EFAttendeeRepo _attendeeRepo;
        EFOrganizerRepo _organizerRepo;
        //ScheduleInMemDao _scheduleDao;

        public PlannerService(PlannerDbContext context)
        {
            _eventRepo = new EFEventRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _activityRepo = new EFActivityRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _attendeeRepo = new EFAttendeeRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            _organizerRepo = new EFOrganizerRepo(context) ?? throw new System.ArgumentNullException(nameof(context));
            //_scheduleDao = new ScheduleInMemDao();
        }

        // BRDIGE GETS FOR EVENTACTIVITIES / EVENTATTENDEES / EVENTORGANIZER

        public List<Activity> GetEventActivities(int id)
        {
            List<Activity> toReturn = _eventRepo.GetEventActivities(id);

            if (toReturn == null)
                throw new NoActivitiesForGivenEventException("No activities were found for this event");
            if (id <= 0)
                throw new InvalidIdException("Invalid id for this event");
           
            return toReturn;
        }

        public List<Attendee> GetEventAttendees(int id)
        {
            List<Attendee> toReturn = _eventRepo.GetEventAttendees(id);

            if (toReturn == null)
                throw new NoAttendeesForGivenEventException("No attendees were found for this event");
            if (id <= 0)
                throw new InvalidIdException("Invalid id for this event");

            return toReturn;
        }

        public Organizer GetEventOrganizer(int id)
        {
            Organizer toReturn = _eventRepo.GetEventOrganizer(id);

            if (toReturn == null)
                throw new NoOrganizerForGivenEventException("No organizer was found for this event");
            if (id <= 0)
                throw new InvalidIdException("Invalid id for this event");

            return toReturn;

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

        public void RemoveActivity(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Can't remove activity with this ID");
            else
            {
                Activity activity = new Activity { Id = id };
                if (activity == null)
                    throw new InvalidActivityException("Activity with this ID does not exist");
                else
                    _activityRepo.RemoveActivity(activity);
            }

        }

        public void RemoveEvent(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Can't remove event with this ID");
            else
            {
                Event thisEvent = new Event { Id = id };
                if (thisEvent == null)
                    throw new InvalidEventException("Event with this ID does not exist");
                else
                    _eventRepo.RemoveEvent(thisEvent);
            }
        }

        public void RemoveOrganizer(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Can't remove organizer with this ID");
            else
            {
                Organizer organizer = new Organizer { Id = id };
                if (organizer == null)
                    throw new InvalidOrganizerException("Organizer with that ID does not exist");
                else
                    _organizerRepo.RemoveOrganizer(organizer);
            }
        }

        public void RemoveAttendee(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Can't remove attendee with this ID");
            else
            {
                Attendee attendee = new Attendee { Id = id };
                if (attendee == null)
                    throw new InvalidAttendeeException("Attendee with that ID does not exist");
                else
                    _attendeeRepo.RemoveAttendee(attendee);
            }
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
