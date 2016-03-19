/*
   Saturday, March 19, 20163:36:17 PM
   User: hambasafe@hsdevdb1
   Server: hsdevdb1.database.windows.net
   Database: hsdevdb1
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Event
	DROP CONSTRAINT FK_Event_EventType
GO
ALTER TABLE dbo.EventType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Event
	DROP CONSTRAINT FK_Event_User
GO
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Event
	(
	EventId int NOT NULL,
	OwnerUserId int NOT NULL,
	EventTypeId int NOT NULL,
	Name varchar(255) NOT NULL,
	DateTimeStart datetime NOT NULL,
	DateTimeEnd datetime NOT NULL,
	Description varchar(MAX) NOT NULL,
	PublicEvent bit NULL,
	MaxWaitingMinutes smallint NOT NULL,
	Attributes varbinary(MAX) NULL,
	DateCreated datetime NULL,
	DateUpdated datetime NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Event SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Event ADD CONSTRAINT
	DF_Event_Public DEFAULT 1 FOR PublicEvent
GO
IF EXISTS(SELECT * FROM dbo.Event)
	 EXEC('INSERT INTO dbo.Tmp_Event (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, Attributes, DateCreated, DateUpdated)
		SELECT EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, Attributes, DateCreated, DateUpdated FROM dbo.Event WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Invitation
	DROP CONSTRAINT FK_Invitation_Event
GO
ALTER TABLE dbo.Attendance
	DROP CONSTRAINT FK_Attendance_Event
GO
DROP TABLE dbo.Event
GO
EXECUTE sp_rename N'dbo.Tmp_Event', N'Event', 'OBJECT' 
GO
ALTER TABLE dbo.Event ADD CONSTRAINT
	PK__Event__3214EC07B4869FF7 PRIMARY KEY CLUSTERED 
	(
	EventId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Event ADD CONSTRAINT
	FK_Event_User FOREIGN KEY
	(
	OwnerUserId
	) REFERENCES dbo.[User]
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Event ADD CONSTRAINT
	FK_Event_EventType FOREIGN KEY
	(
	EventTypeId
	) REFERENCES dbo.EventType
	(
	EventTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Attendance ADD CONSTRAINT
	FK_Attendance_Event FOREIGN KEY
	(
	EventId
	) REFERENCES dbo.Event
	(
	EventId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Attendance SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Invitation ADD CONSTRAINT
	FK_Invitation_Event FOREIGN KEY
	(
	EventId
	) REFERENCES dbo.Event
	(
	EventId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Invitation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
