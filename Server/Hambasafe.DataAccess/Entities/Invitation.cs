using System.ComponentModel.DataAnnotations;
using System;
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
    
        public virtual Event Event { get; set; }
        //public virtual User User { get; set; }
        //public virtual User User1 { get; set; }
    }
}
