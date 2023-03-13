CREATE TABLE [dbo].[UserList] (
    [UserID] INT NULL,
    [ListID] INT NULL,
    CONSTRAINT [FK_List_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[List] ([ListID]),
    CONSTRAINT [FK_User_List] FOREIGN KEY ([ListID]) REFERENCES [dbo].[User] ([UserID])
);

