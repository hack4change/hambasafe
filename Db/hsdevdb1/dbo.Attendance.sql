CREATE TABLE [dbo].[Attendance]
(
	[AttendanceId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    [Attended] BIT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT getdate() 
)
