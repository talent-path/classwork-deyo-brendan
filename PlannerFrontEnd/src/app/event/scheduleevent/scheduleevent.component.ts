import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Event } from 'src/app/interfaces/Event';
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
  @Input('ngModel') orgId: number;

  organizers: Organizer[];

  constructor(private eventService: EventService,
    private organizerService: OrganizerService,
    private router: Router) { }

  ngOnInit(): void {

    this.organizerService.getAllOrganizers().subscribe(list => {
      this.organizers = list;
    })

  }

  addEvent() {
    if (this.category == null || this.category == undefined
      || this.eventDate == null || this.eventDate == undefined
      || this.eventName == null || this.eventName == undefined
      || this.orgId == null || this.orgId == undefined) {
      alert("Please ensure all required information is filled out.");
    }
    else {
      let addEvent: Event = {
        date: this.eventDate, eventName: this.eventName, category: this.category,
        organizerId: this.orgId
      }

      console.log(this.orgId);

      this.eventService.addEvent(addEvent).subscribe((_) => this.router.navigate(["addAttendee"]));
    }
  }

}
