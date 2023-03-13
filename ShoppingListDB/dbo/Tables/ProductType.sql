CREATE TABLE [dbo].[ProductType] (
    [ProductID] INT NULL,
    [TypeID]    INT NULL,
    CONSTRAINT [FK_Product_Type] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_Type_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Type] ([TypeID])
);

