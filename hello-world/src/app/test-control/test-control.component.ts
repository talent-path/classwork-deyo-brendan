import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'test-control',
  templateUrl: './test-control.component.html',
  styleUrls: ['./test-control.component.css']
})
export class TestControlComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  defaultImg : boolean = true;

  imgSrc : string  = "./assets/talentpathlogo.png";

  onClick() : void
  {
    this.defaultImg = !this.defaultImg;
    if (this.defaultImg)
    {
      this.imgSrc = "./assets/talentpathlogo.png";
    }
    else
      this.imgSrc = "./assets/headshot-1.jpeg";
  }

}
