create procedure Proc_Pet_SelectById
@Id int
as
begin
Select Pet.PersonDetailsId,PersonDetails.PersonName, PersonDetails.PersonDob, PersonDetails.PersonAge, Pet.PetBreed from PersonDetails INNER JOIN Pet on  PersonDetails.Id=Pet.PersonDetailsId and PersonDetailsId = @Id;
end