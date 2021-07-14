import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { LoginUserRequest } from '../interfaces/LoginUserRequest';
import { RegisterUserRequest } from '../interfaces/RegisterUserRequest';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username : string;
  password : string;

  constructor(private authService : AuthService,
    private router : Router) { }

  ngOnInit(): void {
  }

  submit() {
    let toSend : LoginUserRequest = {
      Username : this.username, Password : this.password
    }

    this.authService.loginUser(toSend);
  }

  navigate()
  {
    this.router.navigate(["register"]);
  }

}
