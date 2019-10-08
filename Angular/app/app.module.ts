import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { AppComponent }         from './app.component';
import { PersonPetsRoutingModule }     from './Person-Pets/Person-Pets-routing.module';
import {PersonPetsModule} from './Person-Pets/Person-Pets.module';

@NgModule({
  imports: [
    BrowserModule,
    PersonPetsRoutingModule,
    PersonPetsModule
    ],
  declarations: [
    AppComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }