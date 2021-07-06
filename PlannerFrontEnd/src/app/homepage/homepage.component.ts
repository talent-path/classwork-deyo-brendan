import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    
  }

  public slides = [
    "./assets/WaterBalloonFight.jpg",
    "./assets/TugOfWar.jpg",
    "./assets/TheOffice.png"
  ];

}
