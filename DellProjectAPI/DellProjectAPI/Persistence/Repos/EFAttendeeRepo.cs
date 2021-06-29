﻿using DellProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellProjectAPI.Persistence.Repos
{
    public class EFAttendeeRepo : IAttendeeDao
    {
        PlannerDbContext _context;

        public EFAttendeeRepo(PlannerDbContext context)
        {
            _context = context;
        }

        public void AddAttendee(Attendee toAdd)
        {
            _context.Attendees.Add(toAdd);
            _context.SaveChanges();
        }

        public void EditAttendee(Attendee updated)
        {
            _context.Attendees.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Attendee> GetAllAttendees()
        {
            return _context.Attendees.ToList();
        }

        public Attendee GetAttendeeById(int id)
        {
            return _context.Attendees.Find(id);
        }

        public void RemoveAttendee(Attendee toRemove)
        {
            Attendee toDelete = new Attendee
            {
                Id = toRemove.Id
            };
            _context.Attendees.Attach(toDelete);
            _context.Attendees.Remove(toDelete);
            _context.SaveChanges();
        }
    }
}
