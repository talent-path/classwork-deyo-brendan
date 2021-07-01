using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Models
{
    [Table("EventAttendees")]
    public class EventAttendees
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Attendee")]
        public int AttendeeId { get; set; }
        public Event Event { get; set; }
        public Attendee Attendee { get; set; }
        
    }
}
