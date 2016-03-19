CREATE TABLE [dbo].[Event] (
    [EventId]                BIGINT          NOT NULL,
    [OwnerUserId]           BIGINT          NOT NULL,
    [EventTypeId]       SMALLINT        NOT NULL,
    [Name]              VARCHAR (255)   NOT NULL,
    [DateTimeStart]     DATETIME        NOT NULL,
    [DateTimeEnd]       DATETIME        NOT NULL,
    [Description]       TEXT            NOT NULL,
    [MaxWaitingMinutes] SMALLINT        NOT NULL,
    [Attributes]        VARBINARY (MAX) NULL,
    [DateCreated]       DATETIME        NULL,
    [DateUpdated]       DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([EventId] ASC)
);

