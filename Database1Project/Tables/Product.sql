CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(254) NULL, 
    [UserID] INT NOT NULL, 
    CONSTRAINT [FK_Product_User] FOREIGN KEY ([UserID]) REFERENCES [User]([Id]), 
)
