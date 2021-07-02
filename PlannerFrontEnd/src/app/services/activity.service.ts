import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {tap, catchError} from 'rxjs/operators';
import {of} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Activity } from '../interfaces/Activity';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  baseURL : String = "http://localhost:20292/api";

  httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})};

  constructor(private http : HttpClient) { }

  getAllActivities() : Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseURL + "/Activity");
  }

  getActivityById(id : number) : Observable<Activity> {
    return this.http.get<Activity>(this.baseURL + "/Event");
  }

  deleteActivity(id : number) : Observable<Activity> {
    return this.http.delete<Activity>(this.baseURL + "/Event/" + id);
  }

  editActivity(id : number, edited : Activity) : Observable<Activity> {
    return this.http.put<Activity>(this.baseURL + "/Event/" + id, edited, this.httpOptions);
  }

  addActivity(id : number, toAdd : Activity) : Observable<Activity> {
    return this.http.post<Activity>(this.baseURL + "/Event/" + id, toAdd, this.httpOptions);
  }

}
