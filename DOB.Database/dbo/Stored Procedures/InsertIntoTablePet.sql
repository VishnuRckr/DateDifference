 create procedure [dbo].[InsertIntoTablePet]
 --@PersonName VARCHAR(30),
 --@PersonDob DATE,
 --@PersonAge INT,
 --@PetBreed VARCHAR(30)
 @pet PetTable readonly
 as
 begin
 insert into PersonDetails(PersonName,PersonDob,PersonAge) select PersonName,PersonDob,PersonAge from @pet;
 declare @Id INT = scope_identity()
 insert into Pet (PersonDetailsId,PetBreed) values (@Id,(select PetBreed from @pet));
 end