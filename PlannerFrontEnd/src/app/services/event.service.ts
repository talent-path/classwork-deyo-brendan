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
    return this.http.get<Event[]>(this.baseURL + "/Event");
  }
  
  getEventById(id : number) : Observable<Event> {
    return this.http.get<Event>(this.baseURL + "/Event/" + id);
  }

  deleteEvent(id : number) : Observable<Event> {
    return this.http.delete<Event>(this.baseURL + "/Event/" + id);
  }

  editEvent(event : Event, id : number) : Observable<Event> {
    return this.http.put<Event>(this.baseURL + "/Event/" + id, event, this.httpOptions);
  }

  addEvent(toAdd : Event, id : number) : Observable<Event> {
    return this.http.post<Event>(this.baseURL + "/Event/" + id, toAdd, this.httpOptions);
  }

  getEventActivities(id : number) : Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseURL + "/Event/Activities/" + id);
  }

  getEventAttendees(id : number) : Observable<Attendee[]> {
    return this.http.get<Attendee[]>(this.baseURL + "/Event/Attendees/" + id);
  }

  getEventOrganizer(id : number) : Observable<Organizer> {
    return this.http.get<Organizer>(this.baseURL + "/Event/Organizer/" + id);
  }

}


