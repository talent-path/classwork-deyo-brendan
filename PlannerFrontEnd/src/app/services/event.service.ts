import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {tap, catchError} from 'rxjs/operators';
import {of} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Event} from 'src/app/interfaces/Event';
import { Activity } from '../interfaces/Activity';
import { Attendee } from '../interfaces/Attendee';
import { Organizer } from '../interfaces/Organizer';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseURL : String = "http://localhost:20292/api";

  httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})};

  constructor(private http : HttpClient) { }

  getAllEvents() : Observable<Event[]> {
    return this.http.get<Event[]>(this.baseURL + "/Event")
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }
  
  getEventById(id : number) : Observable<Event> {
    return this.http.get<Event>(this.baseURL + "/Event/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  deleteEvent(id : number) : Observable<Event> {
    return this.http.delete<Event>(this.baseURL + "/Event/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  editEvent(event : Event, id : number) : Observable<Event> {
    return this.http.put<Event>(this.baseURL + "/Event/" + id, event, this.httpOptions)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  addEvent(toAdd : Event) : Observable<Event> {
    return this.http.post<Event>(this.baseURL + "/Event/" + toAdd, this.httpOptions)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  getEventActivities(id : number) : Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseURL + "/Event/Activities/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  getEventAttendees(id : number) : Observable<Attendee[]> {
    return this.http.get<Attendee[]>(this.baseURL + "/Event/Attendees/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

  getEventOrganizer(id : number) : Observable<Organizer> {
    return this.http.get<Organizer>(this.baseURL + "/Event/Organizer/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );;
  }

}


