CREATE procedure [dbo].[Proc_PersonDetails_SelectById]
@Id int
As
Begin
Select Id,PersonName,PersonDob, PersonAge from PersonDetails where Id = @Id ;
End