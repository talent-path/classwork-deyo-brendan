import { Activity } from "./Activity";
import { Attendee } from "./Attendee";

export interface Event{
    Id? : number,
    Activities?: Activity[],
    OrganizerId? : number,
    Date : Date,
    EventName : string,
    Duration? : number,
    Attendees? : Attendee[],
    Category : string

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
