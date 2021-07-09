import { ElementSchemaRegistry } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {Event} from 'src/app/interfaces/Event';
import { Organizer } from 'src/app/interfaces/Organizer';
import { EventService } from 'src/app/services/event.service';
import { OrganizerService } from 'src/app/services/organizer.service';

@Component({
  selector: 'app-findevent',
  templateUrl: './findevent.component.html',
  styleUrls: ['./findevent.component.css']
})
export class FindeventComponent implements OnInit {

  eventId : number;
  selectEvent : Event;
  organizer : Organizer;

  constructor(private eventService : EventService,
    private organizerService : OrganizerService) { }

  ngOnInit(): void {
  }

  submit() {
    this.eventService.getEventById(this.eventId).subscribe(event => {
      this.selectEvent = event;

      this.organizerService.getOrganizerById(this.selectEvent.organizerId).subscribe(org => {
        this.organizer = org

        var element = document.getElementById("eventDetails");

        element.style.display = 'block';

        element.innerHTML += `<h1>RESULTS<h1>`;
        element.innerHTML += `<h3>Event Name: ${this.selectEvent.eventName}<br>`;
        element.innerHTML += `<h3>Event Date: ${this.selectEvent.date}<br>`;
        element.innerHTML += `<h3>Organizer: ${this.organizer.name}<br>`;
        element.innerHTML += `<button type = "button" class= "btn btn-success" (click) = "print()">Print Page</button><br><br>`;

      });
    })
  }

  print() {
    window.print();
  }

}
