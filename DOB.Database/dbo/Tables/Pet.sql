CREATE TABLE [dbo].[Pet] (
    [PersonDetailsId] INT          NULL,
    [PetId]           INT          IDENTITY (1, 1) NOT NULL,
    [PetBreed]        VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([PetId] ASC),
    FOREIGN KEY ([PersonDetailsId]) REFERENCES [dbo].[PersonDetails] ([Id])
);



