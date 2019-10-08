import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { pets } from '../Models/pets';
import {appsettings} from '../../appsettings';

const httpOptions = {headers : new HttpHeaders({ 'Access-Control-Allow-Origin':'*','Content-Type' : 'application/json'})};

@Injectable({ providedIn: 'root' })
export class PetService {

  constructor(private http: HttpClient) { }
  
  getPets()
  {
    return this.http.get(appsettings.baseUrl);
  }

  addPets(pet: pets){
    return this.http.post(`${appsettings.baseUrl}/pet`, pet);
  }
  getPet(id:number){
    return this.http.get<pets>(`${appsettings.baseUrl}/getpetbyid/${id}`);
 }
 updatePet(pets : pets){
  return this.http.put(`${appsettings.baseUrl}/petupdate/${pets.Id}`,pets);
}


}