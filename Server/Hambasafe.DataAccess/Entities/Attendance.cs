using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hambasafe.DataAccess.Entities
{
  
    public partial class Attendance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attendance()
        {
            this.AttendanceRatings = new HashSet<AttendanceRating>();
        }
        [Key]
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public bool? HasAttended { get; set; }
        public DateTime DateCreated { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceRating> AttendanceRatings { get; set; }
    }
}
