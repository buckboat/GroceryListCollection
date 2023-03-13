CREATE TABLE [dbo].[List] (
    [ListID]      INT           IDENTITY (1, 1) NOT NULL,
    [ListName]    VARCHAR (100) NULL,
    [CreatedDate] DATETIME      NULL,
    [LastChange]  DATETIME      NULL,
    CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED ([ListID] ASC)
);

