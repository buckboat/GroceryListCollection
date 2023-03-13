CREATE TABLE [dbo].[Product] (
    [ProductID]     INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]   VARCHAR (250)  NULL,
    [ImageURL]      VARCHAR (250)  NULL,
    [NutrtionLabel] VARCHAR (500)  NULL,
    [Description]   VARCHAR (400)  NULL,
    [Price]         DECIMAL (18)   NULL,
    [Ingredient]    VARCHAR (1000) NULL,
    [Quantity]      INT            NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

