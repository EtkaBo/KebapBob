CREATE TABLE [dbo].[OrderItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_OrderItems_Order] FOREIGN KEY ([OrderID]) REFERENCES [Order]([Id]), 
    CONSTRAINT [FK_OrderItems_Product] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id])
)
