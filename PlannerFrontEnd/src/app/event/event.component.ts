import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivityService } from '../services/activity.service';
import { EventService } from '../services/event.service';
import {Event } from 'src/app/interfaces/Event';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  eventList : Event[];
  event : Event;

  constructor(private eventService : EventService,
    private router : Router) { }

  ngOnInit(): void {
    this.eventService.getAllEvents().subscribe(list => {
      this.eventList = list;

      this.event = this.eventList[this.eventList.length - 1];
    });
  }

}
