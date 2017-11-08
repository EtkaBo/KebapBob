CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressID] INT NOT NULL, 
   
    [UserID] INT NOT NULL, 
    [TrackingNumber] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Order_Address] FOREIGN KEY ([AddressID]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserID]) REFERENCES [User]([Id]) 
  
)
