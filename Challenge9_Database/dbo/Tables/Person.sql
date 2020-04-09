CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(50) NULL, 
    [LastName] NCHAR(50) NULL, 
    [Relation] NCHAR(50) NULL, 
    [ResidenceId] INT NULL, 
    [GiftId] INT NULL DEFAULT -1, 
    CONSTRAINT [FK_Person_Redidence] FOREIGN KEY ([ResidenceId]) REFERENCES [Residence]([Id]), 
    CONSTRAINT [FK_Person_Gift] FOREIGN KEY ([GiftId]) REFERENCES [Gift]([Id])
)
