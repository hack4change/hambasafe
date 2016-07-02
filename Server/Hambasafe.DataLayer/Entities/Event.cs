using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataLayer.Entities
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
        public decimal? Distance { get; set; }
        public string Intensity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted  { get; set; }

    [ForeignKey("StartEventLocationId")]
        public virtual EventLocation StartLocation { get; set; }
        [ForeignKey("EndEventLocationId")]
        public virtual EventLocation EndLocation { get; set; }
        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }
        [ForeignKey("OwnerUserId")]
        public virtual User OwnerUser { get; set; }
        
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
