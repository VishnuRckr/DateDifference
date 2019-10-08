import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PetsComponent} from './Components/pets/pets.component';
import { PersonsComponent }      from './Components/persons/persons.component';
import { UpdatepetComponent } from './Components/updatepet/updatepet.component';
import { UpdatepersonComponent } from './Components/updateperson/updateperson.component';


const routes: Routes = [
  { path: '/person', component: PersonsComponent,runGuardsAndResolvers: 'always'},
  { path: '/pet', component: PetsComponent,runGuardsAndResolvers: 'always'},
  {path: '/addpet/:id', component: UpdatepetComponent,runGuardsAndResolvers: 'always'},
  {path:'/addperson/:id', component: UpdatepersonComponent,runGuardsAndResolvers: 'always'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule],
  })
export class PersonPetsRoutingModule {
}