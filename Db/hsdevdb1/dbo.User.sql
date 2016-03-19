CREATE TABLE [dbo].[User] (
    [UserId]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [FirstNames]          VARCHAR (90)  NOT NULL,
    [LastName]            VARCHAR (90)  NOT NULL,
    [Gender]              CHAR   NOT NULL,
    [DateOfBirth]         DATE          NOT NULL,
    [IdentityDocumentUrl] VARCHAR (MAX) NULL,
    [ProfilePictureUrl]   VARCHAR (MAX) NULL,
    [Status]              VARCHAR(90)  DEFAULT ('created') NOT NULL,
    [MobileNumber]        VARCHAR (13)  NOT NULL,
    [EmailAddress]        VARCHAR (90)  NOT NULL,
    [DateCreated]         DATETIME      NOT NULL DEFAULT getdate(),
    [DateUpdated]         DATETIME      NULL,
    [DateValidated]       DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Column]
    ON [dbo].[User]([EmailAddress] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Column_1]
    ON [dbo].[User]([MobileNumber] ASC);

