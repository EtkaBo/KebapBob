CREATE TABLE [dbo].[Tokens]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [AuthToken] NVARCHAR(250) NOT NULL, 
    [IssuedOn] DATETIME NOT NULL, 
    [ExpiresOn] DATETIME NOT NULL, 
    CONSTRAINT [FK_Tokens_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
