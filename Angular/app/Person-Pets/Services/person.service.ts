import { Injectable } from '@angular/core';


import {HttpClient, HttpHeaders} from '@angular/common/http';

import { person } from '../Models/person';



import {appsettings} from '../../appsettings';

const httpOptions = {headers : new HttpHeaders({ 'Access-Control-Allow-Origin':'*','Content-Type' : 'application/json'})};

@Injectable({ providedIn: 'root' })
export class PersonService {
  
 
  constructor(private http: HttpClient) { }
  
  getPersons()
  {
    return this.http.get(appsettings.baseUrl);
  }
  getPerson(id:number){
    return this.http.get<person>(`${appsettings.baseUrl}/getpersonbyid/${id}`);
 }

  addPersons(person: person){
    return this.http.post(`${appsettings.baseUrl}/person`, person);
  }

  updatePerson(person: person){
    return this.http.put(`${appsettings.baseUrl}/personupdate/${person.Id}`,person);
  }
}

