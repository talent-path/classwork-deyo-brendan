import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddattendeeComponent } from './attendee/addattendee/addattendee.component';
import { ContactpageComponent } from './contactpage/contactpage.component';
import { FindeventComponent } from './event/findevent/findevent.component';
import { ScheduleeventComponent } from './event/scheduleevent/scheduleevent.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  {path: "", component : HomepageComponent},
  {path: "contactMe", component : ContactpageComponent},
  {path: "scheduleEvent", component : ScheduleeventComponent},
  {path: "findEvent", component: FindeventComponent},
  {path: "addAttendee", component: AddattendeeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
