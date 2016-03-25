using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hambasafe.DataAccess.Entities
{
   
    
    public  class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Attendances = new HashSet<Attendance>();
            this.Invitations = new HashSet<Invitation>();
        }
        [Key]
        public int EventId { get; set; }
        public int? StartEventLocationId { get; set; }
        public int? EndEventLocationId { get; set; }
        public int OwnerUserId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public string Description { get; set; }
        public bool? IsPublic { get; set; }
        public short MaxWaitingMinutes { get; set; }
        public string Attributes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual EventLocation EventLocation { get; set; }
        public virtual EventLocation EventLocation1 { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
