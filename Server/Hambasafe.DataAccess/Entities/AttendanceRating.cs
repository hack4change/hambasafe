using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{


    public  class AttendanceRating
    {
        [Key]
        public int AttendanceId { get; set; }
        public int RaterUserId { get; set; }
        public int RateeUserId { get; set; }
        public byte? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
    
        public virtual Attendance Attendance { get; set; }
        [ForeignKey("RaterUserId")]
        public virtual User RaterUser { get; set; }
        [ForeignKey("RateeUserId")]
        public virtual User RateeUser { get; set; }
    }
}
