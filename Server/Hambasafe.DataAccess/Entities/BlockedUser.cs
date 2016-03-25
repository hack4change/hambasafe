
using System;
using System.ComponentModel.DataAnnotations;
namespace Hambasafe.DataAccess.Entities
{
  
    public  class BlockedUser
    {
        [Key]
        public int BlockerUserId { get; set; }
        public int BlockedUserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Reason { get; set; }
    
       // public virtual User User { get; set; }
      //  public virtual User User1 { get; set; }
    }
}
