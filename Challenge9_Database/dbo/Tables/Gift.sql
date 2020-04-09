CREATE TABLE [dbo].[Gift]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL, 
    [Cost] DECIMAL NULL, 
    CONSTRAINT [FK_Gift_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
