using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Models
{
    [Table("EventOrganizer")]
    public class EventOrganizer
    {
        [ForeignKey("Event")]
        public int EventId
        {
            get; set;
        }
        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }
        //public Event Event { get; set; }
        //public Organizer Organizer { get; set; }
    }
}
