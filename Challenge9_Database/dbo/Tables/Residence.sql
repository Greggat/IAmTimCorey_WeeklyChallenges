CREATE TABLE [dbo].[Residence]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetAddress] NCHAR(50) NULL, 
    [City] NCHAR(50) NULL, 
    [State] NCHAR(50) NULL, 
    [ZipeCode] NCHAR(10) NULL
)
