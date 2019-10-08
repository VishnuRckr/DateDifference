import { Component, OnInit } from '@angular/core';
import { PetService } from '../../Services/pet.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {
  public pets;
  constructor(private petService: PetService, private router: Router) { }
   
  ngOnInit() {
   
    this.getPets();
  
  }
  editPets(id: number)
  {
    this.router.navigate(['/addpet', id]);
  }
 
  getPets() {
      this.petService.getPets().subscribe(
          data => { this.pets = data[1];console.log(data)},
          err => console.error(err),
          () => console.log('done loading pets')
        );
      }
}