using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{


    public class Event
    {

        public Event()
        {
            Attendances = new HashSet<Attendance>();
            Invitations = new HashSet<Invitation>();
        }
        [Key]
        [Column("EventId")]
        public int Id { get; set; }

        public int OwnerUserId { get; set; }
        public int StartEventLocationId { get; set; }
        public int EndEventLocationId { get; set; }
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

        public virtual ICollection<Attendance> Attendances { get; set; }

        [ForeignKey("StartEventLocationId")]
        public virtual EventLocation StartEventLocation { get; set; }

        [ForeignKey("EndEventLocationId")]
        public virtual EventLocation EndEventLocation { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual User OwnerUser { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
