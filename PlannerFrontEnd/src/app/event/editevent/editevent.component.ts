import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/app/services/event.service';
import { Event } from 'src/app/interfaces/Event';
import { Activity } from 'src/app/interfaces/Activity';
import { Attendee } from 'src/app/interfaces/Attendee';
import { AttendeeService } from 'src/app/services/attendee.service';
import { ActivityService } from 'src/app/services/activity.service';

@Component({
  selector: 'app-editevent',
  templateUrl: './editevent.component.html',
  styleUrls: ['./editevent.component.css']
})
export class EditeventComponent implements OnInit {

  eventID: number;
  eventToEdit: Event;
  attendees: Attendee[];
  activities: Activity[];

  attendeeId: number;
  activityId: number;

  newActivityName: string;
  newActivityDuration: number;

  newAttendeeName: string;
  newAttendeeEmail: string;

  newCategory: string;
  newName: string;
  newDate: Date;
  newTime: string;
  newLocation: string;

  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private eventService: EventService,
    private attendeeService: AttendeeService,
    private activityService: ActivityService) { }

  ngOnInit(): void {
    let idName: string = this.activatedRoute.snapshot.paramMap.get("id");
    this.eventID = parseInt(idName);

    this.eventService.getEventById(this.eventID).subscribe(event => {
      this.eventToEdit = event;

      this.eventService.getEventActivities(this.eventID).subscribe(list => {
        this.activities = list;
      })

      this.eventService.getEventAttendees(this.eventID).subscribe(list => {
        this.attendees = list;
      })
    })
  }

  editActivity() {
    if (this.newActivityDuration == null || this.newActivityName == null ||
      this.newActivityName == undefined || this.newActivityDuration == undefined) {
      alert("Please enter valid information to edit.");
    }
    else {
      let editedActivity: Activity = {
        name: this.newActivityName, duration: this.newActivityDuration, id: this.activityId, eventId: this.eventID
      }

      this.activityService.editActivity(editedActivity).subscribe((_) => console.log(_));

      document.getElementById("activityEdited").innerHTML += `<i>Successfully Edited: ${editedActivity.name}</i>` + "<br>";
      this.newActivityName = '';
      this.newActivityDuration = null;
      this.attendeeId = null;

    }
  }

  editAttendee() {
    if (this.newAttendeeEmail == null || this.newAttendeeEmail == undefined || this.newAttendeeName == null
      || this.newAttendeeName == undefined) {
        alert("Please enter valid information to edit.")
    }
    else
    {
      let editedAttendee : Attendee = {
        id : this.attendeeId, name : this.newAttendeeName, email : this.newAttendeeEmail, eventId : this.eventID 
      }

      this.attendeeService.editAttendee(editedAttendee).subscribe((_) => console.log(_));

      document.getElementById("attendeeEdited").innerHTML += `<i>Successfully Edited: ${editedAttendee.name}</i>` + "<br>";
      this.newAttendeeName = '';
      this.newAttendeeEmail = '';
      this.attendeeId = null;
    }
  }

  editEvent() {
    if (this.newName == null || this.newName == undefined
      || this.newDate == null || this.newDate == undefined) {
      alert("Please enter valid information to edit.")
    }
    else {
      let editedEvent: Event = {
        category: this.newCategory, eventName: this.newName, date: this.newDate,
        organizerId: this.eventToEdit.organizerId, duration: this.eventToEdit.duration,
        attendees: this.eventToEdit.attendees, activities: this.eventToEdit.activities,
        id: this.eventID, location: this.newLocation, time: this.newTime
      };

      this.eventService.editEvent(editedEvent).subscribe((_) => console.log(_));

      document.getElementById("eventEdited").innerHTML += `<i>Successfully Edited: ${editedEvent.eventName}</i>` + "<br>";
      this.newName = '';
      this.newDate = null;

    }
  }

}
