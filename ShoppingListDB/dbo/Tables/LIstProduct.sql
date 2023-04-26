CREATE TABLE [dbo].[LIstProduct] (
    [ListID]    INT NOT NULL,
    [ProductID] INT NULL,
    CONSTRAINT [FK_LIst_Product] FOREIGN KEY ([ListID]) REFERENCES [dbo].[List] ([ListID]),
    CONSTRAINT [FK_Product_LIst] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);







