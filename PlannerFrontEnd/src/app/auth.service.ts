import { Injectable } from '@angular/core';
import {tap, catchError} from 'rxjs/operators';
import {Observable, of} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RegisterUserRequest } from './interfaces/RegisterUserRequest';
import { LoginUserRequest } from './interfaces/LoginUserRequest';
import { UserCredentials } from './interfaces/UserCredentials';
import { Output, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user : UserCredentials = null;
  @Output() loginChangedEvent : EventEmitter<boolean> = new EventEmitter<boolean>();

  baseURL : String = "http://localhost:20292/api";

  httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})};

  constructor(private http : HttpClient) { }


  registerUser(user : RegisterUserRequest) : Observable<boolean> {
    return this.http.post<boolean>(this.baseURL + "/User/Register", user, this.httpOptions)
  }

  loginUser(user : LoginUserRequest) {
    this.http.post<UserCredentials>(this.baseURL + "/User/Login", user, this.httpOptions)
      .subscribe((cred) => this.saveUserAndToken(cred));
  }

  saveUserAndToken(cred : UserCredentials) {
    this.user = cred;
    this.loginChangedEvent.emit(true);
  }

  isSignedIn() : boolean {
    return this.user != null;
  }

  signOut() {
    this.user = null;
    this.loginChangedEvent.emit(false);
  }

}
