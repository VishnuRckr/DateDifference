CREATE Procedure Proc_PersonDetails_Update
@Id int,
@persondetails PersonDetailsTable Readonly
as begin
update PersonDetails
set PersonName=(select PersonName from @persondetails),PersonDob=(select PersonDob from @persondetails),PersonAge=(select PersonAge from @persondetails)
Where Id = @Id;
end