import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Event } from 'src/app/interfaces/Event';
import { Organizer } from 'src/app/interfaces/Organizer';
import { EventService } from 'src/app/services/event.service';
import { OrganizerService } from 'src/app/services/organizer.service';

@Component({
  selector: 'app-scheduleevent',
  templateUrl: './scheduleevent.component.html',
  styleUrls: ['./scheduleevent.component.css']
})
export class ScheduleeventComponent implements OnInit {

  category: string;
  orgName: string;
  eventDate: Date;
  orgEmail: string;
  eventName: string;


  constructor(private eventService : EventService,
    private organizerService : OrganizerService,
    private router : Router) { }

  ngOnInit(): void {
  }

  addEvent() {
    if (this.category == null || this.category == undefined 
      || this.eventDate == null || this.eventDate == undefined
      || this.eventName == null || this.eventName == undefined
      || this.orgEmail == null || this.orgEmail == undefined
      || this.orgName == null || this.orgName == undefined)
      {
        alert("Please ensure all required information is filled out.");
      }

      let addOrg : Organizer = {
        Name : this.orgName, Email : this.orgEmail
      };

      let addEvent : Event = {
        Date : this.eventDate, EventName : this.eventName, Category : this.category 
      }

      this.organizerService.addOrganizer(addOrg).subscribe;
      this.eventService.addEvent(addEvent).subscribe((_) => this.router.navigate((["addAttendee"])));
  }

}
