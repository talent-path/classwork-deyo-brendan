import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    private router: Router) { }

  ngOnInit(): void {
    var hide = document.getElementById("editEvent").style.display = 'none';
  }

  submit() {
    this.eventService.getEventByName(this.eventName).subscribe(event => {
      this.selectEvent = event;

      this.organizerService.getOrganizerById(this.selectEvent.organizerId).subscribe(org => {
        this.organizer = org

        this.eventService.getEventActivities(this.selectEvent.id).subscribe(alist => {
          this.activities = alist;

          this.eventService.getEventAttendees(this.selectEvent.id).subscribe(attList => {
            this.attendees = attList;


            var element = document.getElementById("eventDetails");

            element.style.display = 'block';

            element.innerHTML += `<h1>RESULTS<h1>`;
            element.innerHTML += `<h3>Event Name: ${this.selectEvent.eventName}<br>`;
            element.innerHTML += `<h3>Event Date: ${this.selectEvent.date.toString().substring(0, 10)}<br>`;
            element.innerHTML += `<h3>Organizer: ${this.organizer.name}<br>`;
            element.innerHTML += `<h2><b>Activities</b></h2><br>`;
            element.innerHTML += `<h3><tr *ngFor = "let a of activities"></tr></h3>`;
            element.innerHTML += `<button type = "button" class= "btn btn-success" (click) = "print()">Print Page</button><br><br>`;

            var editElement = document.getElementById("editEvent");

            editElement.style.display = 'block';

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
