using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Models
{
    [Table("EventActivities")]
    public class EventActivities
    {
        [ForeignKey("Event")]
        public int? EventId { get; set; }
        [ForeignKey("Activity")]
        public int? ActivityId { get; set; }
        public Event Event { get; set; }
        public Activity Activity { get; set; }
    }
}
