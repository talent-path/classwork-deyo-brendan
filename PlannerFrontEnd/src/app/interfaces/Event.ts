import { Activity } from "./Activity";
import { Attendee } from "./Attendee";

export interface Event{
    id? : number,
    activities?: Activity[],
    organizerId? : number,
    date : Date,
    eventName : string,
    duration? : number,
    attendees? : Attendee[],
    category : string

}



// public Event()
//         {
//         }
//         [Column("Activities")]
//         public List<Activity> Activities { get; set; }

//         [Required]
//         public int OrganizerId { get; set; }

//         [Required]
//         public DateTime Date { get; set; }

//         [Required]
//         [MaxLength(100)]
//         public string EventName { get; set; }

//         [Column("Id")]
//         public int Id { get; set; }

//         [Column("Attendees")]
//         public List<Attendee> Attendees { get; set; }

//         [Required]
//         public int Duration { get; set; }
