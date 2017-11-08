CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetAddress] VARCHAR(254) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [ZipCode] INT NOT NULL, 
    [RecipientName] VARCHAR(50) NOT NULL, 
)
