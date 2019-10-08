import { Component, OnInit } from '@angular/core';


import { PersonService } from '../../Services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  public persons;
  constructor(private personService: PersonService, private router: Router) { }

  ngOnInit() {
    
    this.getPersons();
  
  }
  editPersons(id: number)
  {
    this.router.navigate(['/addperson', id]);
  }

  getPersons() {
      this.personService.getPersons().subscribe(
          data => { this.persons = data[0];console.log(data)},
          err => console.error(err),
          () => console.log('done loading persons')
        );}
          
}