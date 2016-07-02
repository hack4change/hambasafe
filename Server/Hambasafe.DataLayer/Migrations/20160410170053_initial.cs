using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Hambasafe.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventLocation",
                columns: table => new
                {
                    EventLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.EventLocationId);
                });
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                });
            migrationBuilder.CreateTable(
                name: "ImageResource",
                columns: table => new
                {
                    ImageResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageData = table.Column<byte[]>(nullable: true),
                    MimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageResource", x => x.ImageResourceId);
                });
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LogDescription = table.Column<string>(nullable: true),
                    LogName = table.Column<string>(nullable: true),
                    LogType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogId);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastLogin = table.Column<DateTime>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DateValidated = table.Column<DateTime>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    FirstNames = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdentityDocumentUrl = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PictureImageResourceId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_ImageResource_PictureImageResourceId",
                        column: x => x.PictureImageResourceId,
                        principalTable: "ImageResource",
                        principalColumn: "ImageResourceId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BlockedUser",
                columns: table => new
                {
                    BlockerUserId = table.Column<int>(nullable: false),
                    BlockedUserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUser", x => x.BlockerUserId);
                    table.ForeignKey(
                        name: "FK_BlockedUser_User_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BlockedUser_User_BlockerUserId",
                        column: x => x.BlockerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });
            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ConnectionUserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Relationship = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Connection_User_ConnectionUserId",
                        column: x => x.ConnectionUserId,
                        principalTable: "User",
                        principalColumn: "UserId"
                        );
                    table.ForeignKey(
                        name: "FK_Connection_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attributes = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateTimeEnd = table.Column<DateTime>(nullable: true),
                    DateTimeStart = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EndEventLocationId = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: true),
                    MaxWaitingMinutes = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: false),
                    StartEventLocationId = table.Column<int>(nullable: false),
                    Distance = table.Column<decimal>(nullable: true),
                    Intensity = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_EventLocation_EndEventLocationId",
                        column: x => x.EndEventLocationId,
                        principalTable: "EventLocation",
                        principalColumn: "EventLocationId");
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "EventTypeId");
                    table.ForeignKey(
                        name: "FK_Event_User_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Event_EventLocation_StartEventLocationId",
                        column: x => x.StartEventLocationId,
                        principalTable: "EventLocation",
                        principalColumn: "EventLocationId");
                });
            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    HasAttended = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_Attendance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });
            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    InvitationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    InviteeUserId = table.Column<int>(nullable: true),
                    InvitorUserId = table.Column<int>(nullable: true),
                    OptionalEmailInvitee = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Invitation_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invitation_User_InviteeUserId",
                        column: x => x.InviteeUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invitation_User_InvitorUserId",
                        column: x => x.InvitorUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "AttendanceRating",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceId1 = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    RateeUserId = table.Column<int>(nullable: false),
                    RaterUserId = table.Column<int>(nullable: false),
                    Rating = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRating", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_AttendanceRating_Attendance_AttendanceId1",
                        column: x => x.AttendanceId1,
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceRating_User_RateeUserId",
                        column: x => x.RateeUserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_AttendanceRating_User_RaterUserId",
                        column: x => x.RaterUserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AttendanceRating");
            migrationBuilder.DropTable("BlockedUser");
            migrationBuilder.DropTable("Connection");
            migrationBuilder.DropTable("Invitation");
            migrationBuilder.DropTable("Log");
            migrationBuilder.DropTable("Attendance");
            migrationBuilder.DropTable("Event");
            migrationBuilder.DropTable("EventLocation");
            migrationBuilder.DropTable("EventType");
            migrationBuilder.DropTable("User");
            migrationBuilder.DropTable("ImageResource");
        }
    }
}
