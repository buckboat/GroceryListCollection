CREATE TABLE [dbo].[User] (
    [UserID]        INT           IDENTITY (1, 1) NOT NULL,
    [First Name]    VARCHAR (100) NULL,
    [Last Name]     VARCHAR (100) NULL,
    [Email]         VARCHAR (200) NULL,
    [PasswordHash]  VARCHAR (300) NULL,
    [Salt]          VARCHAR (15)  NULL,
    [DateJoined]    DATETIME      NULL,
    [LastLoginTime] DATETIME      NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

