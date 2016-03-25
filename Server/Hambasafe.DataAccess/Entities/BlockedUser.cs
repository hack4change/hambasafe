
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{
  
    public  class BlockedUser
    {
        [Key]
        public int BlockerUserId { get; set; }
        public int BlockedUserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Reason { get; set; }

        [ForeignKey("BlockerUserId")]
        public virtual User BlockerUser { get; set; }

        [ForeignKey("BlockedUserId")]
        public virtual User Blocked { get; set; }
    }
}
