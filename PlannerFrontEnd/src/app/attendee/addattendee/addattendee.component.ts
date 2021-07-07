import { Component, OnInit } from '@angular/core';
import { Attendee } from 'src/app/interfaces/Attendee';
import { AttendeeService } from 'src/app/services/attendee.service';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-addattendee',
  templateUrl: './addattendee.component.html',
  styleUrls: ['./addattendee.component.css']
})
export class AddattendeeComponent implements OnInit {

  name: string;
  email: string;

  constructor(private attendeeService : AttendeeService,
    private router : Router) { }

  ngOnInit(): void {
  }

  addAttendee() {
    if (this.name == null || this.name == undefined || 
      this.email == null || this.email == undefined)
      {
        alert("Please check all required information is filled out.")
      }

      let toAdd : Attendee = {
        Name : this.name, Email : this.email 
      };

      this.attendeeService.addAttendee(toAdd).subscribe((_) => this.router.navigate(["addAttendee"]));
  }

}
