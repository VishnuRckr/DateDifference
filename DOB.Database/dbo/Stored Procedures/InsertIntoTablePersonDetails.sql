﻿Create procedure [dbo].[InsertIntoTablePersonDetails]
 --@PersonName VARCHAR(30),
 --@PersonDob DATE,
 --@PersonAge INT,

 @persondetails PersonDetailsTable ReadOnly
 as
 begin
 insert into PersonDetails(PersonName,PersonDob,PersonAge) select * from @persondetails;
 end