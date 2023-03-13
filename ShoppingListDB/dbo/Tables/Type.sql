CREATE TABLE [dbo].[Type] (
    [TypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [TypeName] VARCHAR (100) NULL,
    CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED ([TypeID] ASC)
);

