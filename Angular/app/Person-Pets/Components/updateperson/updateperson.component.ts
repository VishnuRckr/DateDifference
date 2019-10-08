import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../Services/person.service';
import { person as Person } from '../../Models/person'
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addperson',
  templateUrl: './updateperson.component.html',
  styleUrls: ['./updateperson.component.css']
})
export class UpdatepersonComponent implements OnInit {
  public person: Person ;
  Name: any;
  Dob: any;
  Age: any;
  Id: any;

  constructor(private personService: PersonService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(parameterMap => {
      const id: any = +parameterMap.get('id');
      this.getPerson(id);
    });
  }
 
  private getPerson(id: number)
  { 
            this.personService.getPerson(id).subscribe( (data: Person) => { 
              if(id!=0)
              {
                this.Id = data.Id,
                this.Name = data.Name,
                this.Dob =  data.Dob,
                this.Age = data.Age.Years       
              }
             });           
 }
  addPersons() {
    let person: Person = {
      Id: this.Id,
      Name: this.Name,
      Dob: this.Dob,
      Age: { Years: this.Age }
    };
    if (this.Id == null)
    {
      this.personService.addPersons(person)
      .subscribe(
        success => alert("Done"),
        error => alert(error),
        ()=> window.location.reload()
      );    
    }  
   else{
   this.personService.updatePerson(person)
     .subscribe(
       success => alert("Done"),
       error => alert(error),
       ()=> window.location.reload()
     );
     }    
  }
}
    
    
 
 
