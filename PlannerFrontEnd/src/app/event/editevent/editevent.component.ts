import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/app/services/event.service';
import {Event} from 'src/app/interfaces/Event';

@Component({
  selector: 'app-editevent',
  templateUrl: './editevent.component.html',
  styleUrls: ['./editevent.component.css']
})
export class EditeventComponent implements OnInit {

  eventID : number;
  eventToEdit : Event;
  
  newCategory : string;
  newName : string;
  newDate : Date;

  constructor(private activatedRoute : ActivatedRoute,
    private router: Router,
    private eventService : EventService) { }

  ngOnInit(): void {
    let idName: string = this.activatedRoute.snapshot.paramMap.get("id");
    this.eventID = parseInt(idName);

    this.eventService.getEventById(this.eventID).subscribe(event => {
      this.eventToEdit = event;
    })
  }

  edit() {
    if(this.newName == null || this.newName == undefined
      || this.newDate == null || this.newDate == undefined)
      {
        alert("Please enter valid information to edit.")
      }
      else
      {
        let editedEvent : Event = {
          category : this.newCategory, eventName : this.newName, date : this.newDate, 
          organizerId : this.eventToEdit.organizerId, duration : this.eventToEdit.duration,
          attendees : this.eventToEdit.attendees, activities : this.eventToEdit.activities,
          id : this.eventID
        };

        this.eventService.editEvent(editedEvent).subscribe((_) => this.router.navigate(["findEvent"]));

      }
  }

}
