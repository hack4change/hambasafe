using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Hambasafe.DataAccess.Entities
{

    public class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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
        public int UserId { get; set; }
        public string Token { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string IdentityDocumentUrl { get; set; }
        public int? PictureImageResourceId { get; set; }
        public string Status { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<System.DateTime> DateValidated { get; set; }
        public Nullable<System.DateTime> DateLastLogin { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Attendance> Attendances { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<AttendanceRating> AttendanceRatings { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<AttendanceRating> AttendanceRatings1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BlockedUser> BlockedUsers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BlockedUser> BlockedUsers1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Connection> Connections { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Connection> Connections1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Event> Events { get; set; }
        //public virtual ImageResource ImageResource { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Invitation> Invitations { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Invitation> Invitations1 { get; set; }
    }
}
