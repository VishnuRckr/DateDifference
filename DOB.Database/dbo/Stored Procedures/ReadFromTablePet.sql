CREATE procedure [dbo].[ReadFromTablePet]
 as
 begin
 Select PersonDetails.PersonName, PersonDetails.PersonDob, PersonDetails.PersonAge, Pet.PetBreed from PersonDetails INNER JOIN Pet on  PersonDetails.Id=Pet.PersonDetailsId;
 end