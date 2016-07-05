using System;

using Hambasafe.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hambasafe.DataLayer.Migrations
{
    [DbContext(typeof(HambasafeDataContext))]
    partial class HambasafeDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "AttendanceId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("EventId");

                    b.Property<bool?>("HasAttended");

                    b.Property<int>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.AttendanceRating", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttendanceId1");

                    b.Property<string>("Comment");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int>("RateeUserId");

                    b.Property<int>("RaterUserId");

                    b.Property<byte?>("Rating");

                    b.HasKey("AttendanceId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.BlockedUser", b =>
                {
                    b.Property<int>("BlockerUserId");

                    b.Property<int>("BlockedUserId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Reason");

                    b.HasKey("BlockerUserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Connection", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ConnectionUserId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Relationship");

                    b.HasKey("UserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "EventId");

                    b.Property<string>("Attributes");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<int>("EndEventLocationId");

                    b.Property<int>("EventTypeId");

                    b.Property<bool?>("IsPublic");

                    b.Property<short>("MaxWaitingMinutes");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerUserId");

                    b.Property<int>("StartEventLocationId");

                    b.Property<decimal>("Distance");

                    b.Property<string>("Intensity");

                    b.Property<bool?>("IsDeleted");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.EventLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "EventLocationId");

                    b.Property<string>("Address");

                    b.Property<string>("Country");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("PostCode");

                    b.Property<string>("Province");

                    b.Property<string>("Suburb");

                    b.Property<string>("City");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "EventTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.ImageResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "ImageResourceId");

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("MimeType");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "InvitationId");

                    b.Property<string>("Comment");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int?>("EventId");

                    b.Property<int?>("InviteeUserId");

                    b.Property<int?>("InvitorUserId");

                    b.Property<string>("OptionalEmailInvitee");

                    b.Property<string>("Status");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "LogId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("LogDescription");

                    b.Property<string>("LogName");

                    b.Property<string>("LogType");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "UserId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateLastLogin");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<DateTime?>("DateValidated");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstNames");

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityDocumentUrl");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNumber");

                    b.Property<int?>("PictureImageResourceId");

                    b.Property<string>("Status");

                    b.Property<string>("Token");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Attendance", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.AttendanceRating", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.Attendance")
                        .WithMany()
                        .HasForeignKey("AttendanceId1");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("RateeUserId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("RaterUserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.BlockedUser", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("BlockedUserId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("BlockerUserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Connection", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("ConnectionUserId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Event", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.EventLocation")
                        .WithMany()
                        .HasForeignKey("EndEventLocationId");

                    b.HasOne("Hambasafe.DataLayer.Entities.EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");

                    b.HasOne("Hambasafe.DataLayer.Entities.EventLocation")
                        .WithMany()
                        .HasForeignKey("StartEventLocationId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.Invitation", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("InviteeUserId");

                    b.HasOne("Hambasafe.DataLayer.Entities.User")
                        .WithMany()
                        .HasForeignKey("InvitorUserId");
                });

            modelBuilder.Entity("Hambasafe.DataLayer.Entities.User", b =>
                {
                    b.HasOne("Hambasafe.DataLayer.Entities.ImageResource")
                        .WithMany()
                        .HasForeignKey("PictureImageResourceId");
                });
        }
    }
}
