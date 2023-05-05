CREATE TABLE [dbo].[LIstProduct] (
    [ListID]          INT          NOT NULL,
    [ProductID]       INT          NULL,
    [ProductQuantity] INT          CONSTRAINT [DF_LIstProduct_ProductQuantity] DEFAULT ((1)) NULL,
    [Discount]        DECIMAL (18) CONSTRAINT [DF_LIstProduct_Discount] DEFAULT ((0)) NULL,
    CONSTRAINT [FK_LIst_Product] FOREIGN KEY ([ListID]) REFERENCES [dbo].[List] ([ListID]),
    CONSTRAINT [FK_Product_LIst] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);













