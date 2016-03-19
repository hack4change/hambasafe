CREATE TABLE [dbo].[EventType] (
    [EventTypeId]          SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (90) NOT NULL,
    [Description] TEXT         NULL,
    PRIMARY KEY CLUSTERED ([EventTypeId] ASC)
);

