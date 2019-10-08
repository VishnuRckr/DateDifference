CREATE procedure [dbo].[Proc_Pet_Select]
 as
 begin
 Select Pet.PersonDetailsId,PersonDetails.PersonName, PersonDetails.PersonDob, PersonDetails.PersonAge, Pet.PetBreed from PersonDetails INNER JOIN Pet on  PersonDetails.Id=Pet.PersonDetailsId;
 end