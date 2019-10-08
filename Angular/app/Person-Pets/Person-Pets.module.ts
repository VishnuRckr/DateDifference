import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';

import { AppComponent }         from '../app.component';
import { PersonsComponent}      from './Components/persons/persons.component';


import { PersonPetsRoutingModule }     from './Person-Pets-routing.module';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { PetsComponent } from './Components/pets/pets.component';
import { UpdatepetComponent } from './Components/updatepet/updatepet.component';
import { UpdatepersonComponent } from './Components/updateperson/updateperson.component';
import { HttpErrorInterceptor } from '../error-interceptor';
@NgModule({
    imports: [
      BrowserModule,
      FormsModule,
      PersonPetsRoutingModule,
      HttpClientModule
    ],
    declarations: [
        AppComponent,
      PersonsComponent, 
      PetsComponent, UpdatepetComponent, UpdatepersonComponent
    ],
    exports: [
        PersonsComponent, 
      PetsComponent, UpdatepetComponent, UpdatepersonComponent
    ],
    providers: [
      {
        provide: HTTP_INTERCEPTORS,
        useClass: HttpErrorInterceptor,
        multi: true,
      }],
      bootstrap:[AppComponent]
  })
  export class PersonPetsModule { }