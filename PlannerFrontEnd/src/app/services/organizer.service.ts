import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {tap, catchError} from 'rxjs/operators';
import {of} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Organizer } from '../interfaces/Organizer';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService {

  baseURL : String = "http://localhost:20292/api";

  httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})};

  constructor(private http : HttpClient) { }

  getAllOrganizers() : Observable<Organizer[]> {
    return this.http.get<Organizer[]>(this.baseURL + "/Organizer");
  }
  
  getOrganizerById(id : number) : Observable<Organizer> {
    return this.http.get<Organizer>(this.baseURL + "/Organizer/" + id);
  }

  deleteOrganizer(id : number) : Observable<Organizer> {
    return this.http.delete<Organizer>(this.baseURL + "/Organizer/" + id);
  }

  editEvent(o : Organizer, id : number) : Observable<Organizer> {
    return this.http.put<Organizer>(this.baseURL + "/Organizer/" + id, o, this.httpOptions);
  }

  addEvent(toAdd : Organizer, id : number) : Observable<Organizer> {
    return this.http.post<Organizer>(this.baseURL + "/Organizer/" + id, toAdd, this.httpOptions);
  }

}
