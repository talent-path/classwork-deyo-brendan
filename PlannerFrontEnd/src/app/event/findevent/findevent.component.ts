import { listLazyRoutes } from '@angular/compiler/src/aot/lazy_routes';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { Activity } from 'src/app/interfaces/Activity';
import { Attendee } from 'src/app/interfaces/Attendee';
import { Event } from 'src/app/interfaces/Event';
import { Organizer } from 'src/app/interfaces/Organizer';
import { EventService } from 'src/app/services/event.service';
import { OrganizerService } from 'src/app/services/organizer.service';

@Component({
  selector: 'app-findevent',
  templateUrl: './findevent.component.html',
  styleUrls: ['./findevent.component.css']
})
export class FindeventComponent implements OnInit {

  eventName: string;
  selectEvent: Event;
  organizer: Organizer;

  activities: Activity[];
  attendees: Attendee[];

  constructor(private eventService: EventService,
    private organizerService: OrganizerService,
    private router: Router,
    private authService : AuthService) { }

  ngOnInit(): void {
    
  }

  submit() {
    this.eventService.getEventByName(this.eventName).subscribe(event => {
      this.selectEvent = event;

      this.organizerService.getOrganizerById(this.selectEvent.organizerId).subscribe(org => {
        this.organizer = org

        this.eventService.getEventActivities(this.selectEvent.id).subscribe(actList => {
          this.activities = actList;

          this.eventService.getEventAttendees(this.selectEvent.id).subscribe(attList => {
            this.attendees = attList;

            var element = document.getElementById("eventDetails");

            element.style.display = 'block';

            element.innerHTML += `<h1>EVENT SUMMARY<h1>`;
            element.innerHTML += `<h3>Event Name: ${this.selectEvent.eventName}<br>`;
            element.innerHTML += `<h3>Event Date: ${this.selectEvent.date.toString().substring(0, 10)}<br>`;
            element.innerHTML += `<h3>Organizer: ${this.organizer.name}<br>`;

            var editElement = document.getElementById("editEvent");

            editElement.style.display = 'inline-block';

            var attendeeDiv = document.getElementById("attendees");
            var activityDiv = document.getElementById("activities");

            attendeeDiv.style.display = 'block';
            activityDiv.style.display = 'block';

          })
        })
      })
    });
  }

  navigate() {
    this.router.navigate(["editEvent/" + this.selectEvent.id]);
  }

  print() {
    window.print();
  }

}
