using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hambasafe.DataLayer.Entities
{

    public class User : IdentityUser<int>
    {
        public User()
        {
            //Attendances = new HashSet<Attendance>();
            //AttendanceRatings = new HashSet<AttendanceRating>();
            //AttendanceRatings1 = new HashSet<AttendanceRating>();
            //BlockedUsers = new HashSet<BlockedUser>();
            //BlockedUsers1 = new HashSet<BlockedUser>();
            //Connections = new HashSet<Connection>();
            //Connections1 = new HashSet<Connection>();
            //Events = new HashSet<Event>();
            //Invitations = new HashSet<Invitation>();
            //Invitations1 = new HashSet<Invitation>();
        }
        [Key]
        [Column("UserId")]
        
        public string Token { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityDocumentUrl { get; set; }
        public int? PictureImageResourceId { get; set; }
        public string Status { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateValidated { get; set; }
        public DateTime? DateLastLogin { get; set; }

        //implement as needed

        //public virtual ICollection<Attendance> Attendances { get; set; }
        //public virtual ICollection<AttendanceRating> AttendanceRatings { get; set; }
        //public virtual ICollection<AttendanceRating> AttendanceRatings1 { get; set; }
        //public virtual ICollection<BlockedUser> BlockedUsers { get; set; }
        //public virtual ICollection<BlockedUser> BlockedUsers1 { get; set; }
        //public virtual ICollection<Connection> Connections { get; set; }
        //public virtual ICollection<Connection> Connections1 { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        [ForeignKey("PictureImageResourceId")]
        public virtual ImageResource PictureImageResource { get; set; }
        //public virtual ICollection<Invitation> Invitations { get; set; }
        //public virtual ICollection<Invitation> Invitations1 { get; set; }
    }
}
