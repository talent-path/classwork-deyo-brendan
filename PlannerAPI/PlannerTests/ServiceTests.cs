using System;
using Xunit;
using Moq;
using PlannerAPI.Services;
using PlannerAPI.Persistence.Repos;
using PlannerAPI.Persistence;
using PlannerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PlannerTests
{
    public class ServiceTests
    {
        [Fact]
        public void CreatingAnEventSavesAnEventViaContext()
        {
            Event toAdd = new Event
            {
                Id = 1,
                EventName = "Test Event",
                Date = new DateTime(1997, 06, 28),
                Duration = 150,
                Activities = new List<Activity>(),
                Attendees = new List<Attendee>(),
                Organizer = new Organizer()
            };

            var mockSet = new Mock<DbSet<Event>>();

            var mockContext = new Mock<PlannerDbContext>();

            var mockService = new ProjectService(mockContext.Object);

            mockService.AddEvent(toAdd);

            mockSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
