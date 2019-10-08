import { Component, OnInit } from '@angular/core';
import { pets } from '../../Models/pets';
import { PetService } from '../../Services/pet.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addpet',
  templateUrl: './updatepet.component.html',
  styleUrls: ['./updatepet.component.css']
})
export class UpdatepetComponent implements OnInit {
  public pet;
  Name: any;
  Dob: Date;
  Age: any;
  PetBreed: string;
  Id: any;

  constructor(private petService: PetService, private route: ActivatedRoute ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(parameterMap => {
      const id: any = +parameterMap.get('id');
      this.getPet(id);
    });
  }
  private getPet(id: number)
  { 
            this.petService.getPet(id).subscribe( (data: pets) => { 
              console.log(data);
              if(id!=0){
                this.Id = data.Id,
                this.Name = data.Name,
                this.Dob =  data.Dob,
                this.Age = data.Age.Years,
                this.PetBreed = data.PetBreed
              }
              });     
  }          

  addPets(){
    let pet : pets = {
      Id: this.Id,
      Name: this.Name,
      Dob: this.Dob,  
      Age: {years : this.Age },
      PetBreed : this.PetBreed
    };
    if(this.Id==null)
    {
      this.petService.addPets(pet)
      .subscribe(
        success => alert("Done"),
        error => alert(error),
        ()=> window.location.reload()
      );
    }
    else{
      this.petService.updatePet(pet)
      .subscribe(
        success => alert("Done"),
        error => alert(error),
        ()=> window.location.reload()
      );
    }
  }
}


