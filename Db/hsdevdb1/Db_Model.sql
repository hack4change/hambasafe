USE [hsdevdb1]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_alterdiagram]
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_creatediagram]
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_dropdiagram]
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_helpdiagramdefinition]
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_helpdiagrams]
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_renamediagram]
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_upgraddiagrams]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invitation]') AND type in (N'U'))
ALTER TABLE [dbo].[Invitation] DROP CONSTRAINT IF EXISTS [FK_Invitation_User1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invitation]') AND type in (N'U'))
ALTER TABLE [dbo].[Invitation] DROP CONSTRAINT IF EXISTS [FK_Invitation_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invitation]') AND type in (N'U'))
ALTER TABLE [dbo].[Invitation] DROP CONSTRAINT IF EXISTS [FK_Invitation_Event]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friend]') AND type in (N'U'))
ALTER TABLE [dbo].[Friend] DROP CONSTRAINT IF EXISTS [FK_Friend_User1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friend]') AND type in (N'U'))
ALTER TABLE [dbo].[Friend] DROP CONSTRAINT IF EXISTS [FK_Friend_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
ALTER TABLE [dbo].[Event] DROP CONSTRAINT IF EXISTS [FK_Event_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
ALTER TABLE [dbo].[Event] DROP CONSTRAINT IF EXISTS [FK_Event_EventType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlockedUser]') AND type in (N'U'))
ALTER TABLE [dbo].[BlockedUser] DROP CONSTRAINT IF EXISTS [FK_BlockedUser_User1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlockedUser]') AND type in (N'U'))
ALTER TABLE [dbo].[BlockedUser] DROP CONSTRAINT IF EXISTS [FK_BlockedUser_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceRating]') AND type in (N'U'))
ALTER TABLE [dbo].[AttendanceRating] DROP CONSTRAINT IF EXISTS [FK_AttendanceRating_User1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceRating]') AND type in (N'U'))
ALTER TABLE [dbo].[AttendanceRating] DROP CONSTRAINT IF EXISTS [FK_AttendanceRating_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceRating]') AND type in (N'U'))
ALTER TABLE [dbo].[AttendanceRating] DROP CONSTRAINT IF EXISTS [FK_AttendanceRating_Attendance]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_Event]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [DF__User__DateCreate__412EB0B6]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [DF__User__Status__403A8C7D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invitation]') AND type in (N'U'))
ALTER TABLE [dbo].[Invitation] DROP CONSTRAINT IF EXISTS [DF_Invitations_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friend]') AND type in (N'U'))
ALTER TABLE [dbo].[Friend] DROP CONSTRAINT IF EXISTS [DF_Friend_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlockedUser]') AND type in (N'U'))
ALTER TABLE [dbo].[BlockedUser] DROP CONSTRAINT IF EXISTS [DF_Blocked_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [DF__Attendanc__DateC__440B1D61]
GO
/****** Object:  Index [IX_User_Column_1]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP INDEX IF EXISTS [IX_User_Column_1] ON [dbo].[User]
GO
/****** Object:  Index [IX_User_Column]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP INDEX IF EXISTS [IX_User_Column] ON [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[sysdiagrams]
GO
/****** Object:  Table [dbo].[Invitation]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[Invitation]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[Friend]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[EventType]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[Event]
GO
/****** Object:  Table [dbo].[BlockedUser]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[BlockedUser]
GO
/****** Object:  Table [dbo].[AttendanceRating]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[AttendanceRating]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 3/19/2016 4:10:30 AM ******/
DROP TABLE IF EXISTS [dbo].[Attendance]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 3/19/2016 4:10:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Attended] [bit] NULL,
	[DateCreated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
/****** Object:  Table [dbo].[AttendanceRating]    Script Date: 3/19/2016 4:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceRating]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AttendanceRating](
	[AttendanceId] [int] NOT NULL,
	[RaterUserId] [int] NOT NULL,
	[RateeUserId] [int] NOT NULL,
	[Rating] [int] NULL,
	[Comment] [varchar](max) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_AttendanceRating] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC,
	[RaterUserId] ASC,
	[RateeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BlockedUser]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlockedUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BlockedUser](
	[BlockerUserId] [int] NOT NULL,
	[BlockedUserId] [int] NOT NULL,
	[DateCreated] [datetime] NULL,
	[Reason] [varchar](250) NULL,
 CONSTRAINT [PK_Blocked] PRIMARY KEY CLUSTERED 
(
	[BlockerUserId] ASC,
	[BlockedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Event]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Event](
	[EventId] [int] NOT NULL,
	[OwnerUserId] [int] NOT NULL,
	[EventTypeId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[DateTimeStart] [datetime] NOT NULL,
	[DateTimeEnd] [datetime] NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[MaxWaitingMinutes] [smallint] NOT NULL,
	[Attributes] [varbinary](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK__Event__3214EC07B4869FF7] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventType](
	[EventTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](90) NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK__EventTyp__3214EC07A1180B85] PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friend]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Friend](
	[UserId] [int] NOT NULL,
	[FriendUserId] [int] NOT NULL,
	[Relationship] [varchar](90) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FriendUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invitation]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invitation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Invitation](
	[InvitationId] [int] IDENTITY(1,1) NOT NULL,
	[InvitorUserId] [int] NULL,
	[InviteeUserId] [int] NULL,
	[EventId] [int] NULL,
	[OptionalEmailInvitee] [varchar](254) NULL,
	[DateCreated] [datetime] NULL,
	[Status] [varchar](10) NULL,
	[StatusReason] [varchar](250) NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_Invitations] PRIMARY KEY CLUSTERED 
(
	[InvitationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/19/2016 4:10:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstNames] [varchar](90) NOT NULL,
	[LastName] [varchar](90) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[IdentityDocumentUrl] [varchar](max) NULL,
	[ProfilePictureUrl] [varchar](max) NULL,
	[Status] [varchar](90) NOT NULL,
	[MobileNumber] [varchar](13) NOT NULL,
	[EmailAddress] [varchar](254) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[DateValidated] [datetime] NULL,
 CONSTRAINT [PK__User__3214EC074B4F67B0] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Column]    Script Date: 3/19/2016 4:10:36 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IX_User_Column')
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Column] ON [dbo].[User]
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Column_1]    Script Date: 3/19/2016 4:10:36 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IX_User_Column_1')
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Column_1] ON [dbo].[User]
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Attendanc__DateC__440B1D61]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Attendance] ADD  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Blocked_DateCreated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BlockedUser] ADD  CONSTRAINT [DF_Blocked_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Friend_DateCreated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Friend] ADD  CONSTRAINT [DF_Friend_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Invitations_DateCreated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Invitation] ADD  CONSTRAINT [DF_Invitations_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__User__Status__403A8C7D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__Status__403A8C7D]  DEFAULT ('created') FOR [Status]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__User__DateCreate__412EB0B6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__DateCreate__412EB0B6]  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendance]'))
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendance]'))
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Event]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendance]'))
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendance]'))
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_Attendance]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceRating_Attendance] FOREIGN KEY([AttendanceId])
REFERENCES [dbo].[Attendance] ([AttendanceId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_Attendance]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating] CHECK CONSTRAINT [FK_AttendanceRating_Attendance]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceRating_User] FOREIGN KEY([RaterUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating] CHECK CONSTRAINT [FK_AttendanceRating_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceRating_User1] FOREIGN KEY([RateeUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AttendanceRating_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AttendanceRating]'))
ALTER TABLE [dbo].[AttendanceRating] CHECK CONSTRAINT [FK_AttendanceRating_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BlockedUser_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlockedUser]'))
ALTER TABLE [dbo].[BlockedUser]  WITH CHECK ADD  CONSTRAINT [FK_BlockedUser_User] FOREIGN KEY([BlockerUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BlockedUser_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlockedUser]'))
ALTER TABLE [dbo].[BlockedUser] CHECK CONSTRAINT [FK_BlockedUser_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BlockedUser_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlockedUser]'))
ALTER TABLE [dbo].[BlockedUser]  WITH CHECK ADD  CONSTRAINT [FK_BlockedUser_User1] FOREIGN KEY([BlockedUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BlockedUser_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlockedUser]'))
ALTER TABLE [dbo].[BlockedUser] CHECK CONSTRAINT [FK_BlockedUser_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Event_EventType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Event]'))
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([EventTypeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Event_EventType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Event]'))
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Event_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Event]'))
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([OwnerUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Event_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Event]'))
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Friend_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Friend]'))
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User] FOREIGN KEY([FriendUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Friend_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Friend]'))
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Friend_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Friend]'))
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Friend_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Friend]'))
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation]  WITH CHECK ADD  CONSTRAINT [FK_Invitation_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation] CHECK CONSTRAINT [FK_Invitation_Event]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation]  WITH CHECK ADD  CONSTRAINT [FK_Invitation_User] FOREIGN KEY([InvitorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation] CHECK CONSTRAINT [FK_Invitation_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation]  WITH CHECK ADD  CONSTRAINT [FK_Invitation_User1] FOREIGN KEY([InviteeUserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Invitation_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Invitation]'))
ALTER TABLE [dbo].[Invitation] CHECK CONSTRAINT [FK_Invitation_User1]
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_upgraddiagrams]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_upgraddiagrams] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_renamediagram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_renamediagram] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagrams]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_helpdiagrams] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagramdefinition]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_dropdiagram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_dropdiagram] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_creatediagram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_creatediagram] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 3/19/2016 4:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_alterdiagram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_alterdiagram] AS' 
END
GO

	ALTER PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
