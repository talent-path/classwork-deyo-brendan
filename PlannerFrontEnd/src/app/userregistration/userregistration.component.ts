import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { RegisterUserRequest } from '../interfaces/RegisterUserRequest';

@Component({
  selector: 'app-userregistration',
  templateUrl: './userregistration.component.html',
  styleUrls: ['./userregistration.component.css']
})
export class UserregistrationComponent implements OnInit {

  userName : string;
  userPassword : string;
  userEmail : string;
  confirmPassword : string;

  constructor(private authService : AuthService,
    private router : Router) { }

  ngOnInit(): void {
  }

  submit() {

    let toSend : RegisterUserRequest = {
      Username : this.userName, Password : this.userPassword, Email : this.userEmail
    }

    this.authService.registerUser(toSend).subscribe((_) => this.router.navigate(["login"]));
  }

}
