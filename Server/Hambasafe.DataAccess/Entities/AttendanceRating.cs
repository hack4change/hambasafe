using System;
using System.ComponentModel.DataAnnotations;

namespace Hambasafe.DataAccess.Entities
{


    public  class AttendanceRating
    {
        [Key]
        public int AttendanceId { get; set; }
        public int RaterUserId { get; set; }
        public int RateeUserId { get; set; }
        public Nullable<byte> Rating { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Attendance Attendance { get; set; }
      //  public virtual User User { get; set; }
       // public virtual User User1 { get; set; }
    }
}
