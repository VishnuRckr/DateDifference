CREATE procedure Proc_PersonDetails_SelectById
@Id int
As
Begin
Select PersonName,PersonDob, PersonAge from PersonDetails where Id = @Id ;
End