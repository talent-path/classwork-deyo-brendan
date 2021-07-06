import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactpageComponent } from './contactpage/contactpage.component';
import { EventpageComponent } from './eventpage/eventpage/eventpage.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  {path: "home", component : HomepageComponent},
  {path: "contact", component : ContactpageComponent},
  {path: "event", component : EventpageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
