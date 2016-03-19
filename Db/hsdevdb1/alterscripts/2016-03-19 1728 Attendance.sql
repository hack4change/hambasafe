/*
   Saturday, March 19, 20165:27:34 PM
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
select Has_Perms_By_Name(N'dbo.EventType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EventType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EventType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Event
	DROP CONSTRAINT FK_Event_User
GO
ALTER TABLE dbo.Attendance
	DROP CONSTRAINT FK_Attendance_User
GO
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.[User]', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Event
	DROP CONSTRAINT DF_Event_Public
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
	DateCreated datetime NOT NULL,
	DateUpdated datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Event SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Event ADD CONSTRAINT
	DF_Event_Public DEFAULT 1 FOR PublicEvent
GO
IF EXISTS(SELECT * FROM dbo.Event)
	 EXEC('INSERT INTO dbo.Tmp_Event (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, PublicEvent, MaxWaitingMinutes, Attributes, DateCreated, DateUpdated)
		SELECT EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, PublicEvent, MaxWaitingMinutes, Attributes, DateCreated, DateUpdated FROM dbo.Event WITH (HOLDLOCK TABLOCKX)')
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
select Has_Perms_By_Name(N'dbo.Event', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Event', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Event', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
select Has_Perms_By_Name(N'dbo.Invitation', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Invitation', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Invitation', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Attendance
	DROP CONSTRAINT DF__Attendanc__DateC__440B1D61
GO
CREATE TABLE dbo.Tmp_Attendance
	(
	AttendanceId int NOT NULL IDENTITY (1, 1),
	UserId int NOT NULL,
	EventId int NOT NULL,
	Attended bit NULL,
	DateCreated datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Attendance SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Attendance ADD CONSTRAINT
	DF__Attendanc__DateC__440B1D61 DEFAULT (getdate()) FOR DateCreated
GO
SET IDENTITY_INSERT dbo.Tmp_Attendance ON
GO
IF EXISTS(SELECT * FROM dbo.Attendance)
	 EXEC('INSERT INTO dbo.Tmp_Attendance (AttendanceId, UserId, EventId, Attended, DateCreated)
		SELECT AttendanceId, UserId, EventId, Attended, DateCreated FROM dbo.Attendance WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Attendance OFF
GO
ALTER TABLE dbo.AttendanceRating
	DROP CONSTRAINT FK_AttendanceRating_Attendance
GO
DROP TABLE dbo.Attendance
GO
EXECUTE sp_rename N'dbo.Tmp_Attendance', N'Attendance', 'OBJECT' 
GO
ALTER TABLE dbo.Attendance ADD CONSTRAINT
	PK__Attendan__8B69261C4F87B14C PRIMARY KEY CLUSTERED 
	(
	AttendanceId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Attendance ADD CONSTRAINT
	FK_Attendance_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
COMMIT
select Has_Perms_By_Name(N'dbo.Attendance', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Attendance', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Attendance', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AttendanceRating ADD CONSTRAINT
	FK_AttendanceRating_Attendance FOREIGN KEY
	(
	AttendanceId
	) REFERENCES dbo.Attendance
	(
	AttendanceId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AttendanceRating SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AttendanceRating', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AttendanceRating', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AttendanceRating', 'Object', 'CONTROL') as Contr_Per 