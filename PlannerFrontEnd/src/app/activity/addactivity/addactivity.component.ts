import { Component, OnInit } from '@angular/core';
import { Activity } from 'src/app/interfaces/Activity';
import {Event} from 'src/app/interfaces/Event';
import { ActivityService } from 'src/app/services/activity.service';
import { EventService } from 'src/app/services/event.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-addactivity',
  templateUrl: './addactivity.component.html',
  styleUrls: ['./addactivity.component.css']
})
export class AddactivityComponent implements OnInit {

  duration : number;
  name : string;

  eventList : Event[];

  event : Event;

  constructor(private eventService : EventService,
    private activityService : ActivityService,
    private router : Router) { }

  ngOnInit(): void {
    this.eventService.getAllEvents().subscribe(list => {
      this.eventList = list;

      this.event = this.eventList[this.eventList.length - 1];
    });
  }

  addActivity() {
    if (this.name == null || this.name == undefined ||
      this.duration == null || this.duration == undefined) {
      alert("Please check all required information is filled out.")
    }

    let toAdd : Activity = {
      name : this.name, duration : this.duration, eventId : this.event.id
    }

    this.activityService.addActivity(toAdd).subscribe((_) => console.log(_));

    document.getElementById("activityAdded").innerHTML += `Added: ${toAdd.name}` + "<br>";
    this.name = '';
    this.duration = null;

  }

  nextPage() {
    this.router.navigate(["confirmEvent"]);
  }

}
