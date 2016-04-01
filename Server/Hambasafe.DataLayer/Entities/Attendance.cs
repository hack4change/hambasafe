using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataLayer.Entities
{

    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceRatings = new HashSet<AttendanceRating>();
        }
        [Key]
        [Column("AttendanceId")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public bool? HasAttended { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AttendanceRating> AttendanceRatings { get; set; }
    }
}
