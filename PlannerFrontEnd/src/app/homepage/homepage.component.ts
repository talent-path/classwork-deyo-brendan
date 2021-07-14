import { getSourceFileOrError } from '@angular/compiler-cli/src/ngtsc/file_system';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Organizer } from '../interfaces/Organizer';
import { EventService } from '../services/event.service';
import { OrganizerService } from '../services/organizer.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  eventName : string = "Event";
  
  username : string = "user";

  signedIn : boolean = false;

  organizer : Organizer;

  constructor(private eventService : EventService,
    private authService : AuthService,
    private orgService : OrganizerService) { }

  ngOnInit(): void {

    this.signedIn = this.authService.isSignedIn();

    if(this.signedIn){
      this.getUser();
    }

    this.authService.loginChangedEvent.subscribe((signedIn) => this.signedIn = signedIn);
  }

  getUser() {
    this.orgService.getUserAsOrganizer().subscribe(org => this.organizer = org);
  }

  public slides = [
    "./assets/WaterBalloonFight.jpg",
    "./assets/TugOfWar.jpg",
    "./assets/TheOffice.png"
  ];

}
