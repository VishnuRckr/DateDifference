create Procedure [dbo].[Proc_Pet_Update]
@Id int,
@pet PetTable Readonly
as begin
update Pet
set PetBreed = (select PetBreed from @pet)
where PersonDetailsId = @Id;

update PersonDetails
set PersonName = (select PersonName from @pet),PersonDob = (select PersonDob from @pet), PersonAge = (select PersonAge from @pet)
where Id = @Id;
end