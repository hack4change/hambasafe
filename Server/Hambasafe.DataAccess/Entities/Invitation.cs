using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{
    

    public  class Invitation
    {
        [Key]
        public int InvitationId { get; set; }
        public int? InvitorUserId { get; set; }
        public int? InviteeUserId { get; set; }
        public int? EventId { get; set; }
        public string OptionalEmailInvitee { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? DateUpdated { get; set; }
    
        public virtual Event InvitorUser { get; set; }
        [ForeignKey("InvitorUserId")]
        public virtual User User { get; set; }
        [ForeignKey("InviteeUserId")]
        public virtual User InviteeUser { get; set; }
    }
}
