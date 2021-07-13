import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  eventName : string = "Event";
  
  username : string;

  constructor(private eventService : EventService,
    private authService : AuthService) { }

  ngOnInit(): void {
    this.authService.loginChangedEvent.subscribe((bool) => console.log(this.authService.user));

  }

  public slides = [
    "./assets/WaterBalloonFight.jpg",
    "./assets/TugOfWar.jpg",
    "./assets/TheOffice.png"
  ];

}
