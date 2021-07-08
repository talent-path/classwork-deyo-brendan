import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  eventName : string = "Event";

  constructor(private eventService : EventService) { }

  ngOnInit(): void {

      this.eventService.getEventById(2).subscribe(e => {
        this.eventName = e.eventName;
      });
    
  }

  public slides = [
    "./assets/WaterBalloonFight.jpg",
    "./assets/TugOfWar.jpg",
    "./assets/TheOffice.png"
  ];

}
