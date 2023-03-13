CREATE TABLE [dbo].[LIstProduct] (
    [ListID]    INT NOT NULL,
    [ProductID] INT NULL,
    CONSTRAINT [PK_LIstProduct] PRIMARY KEY CLUSTERED ([ListID] ASC),
    CONSTRAINT [FK_LIst_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[User] ([UserID]),
    CONSTRAINT [FK_Product_LIs] FOREIGN KEY ([ListID]) REFERENCES [dbo].[Product] ([ProductID])
);

