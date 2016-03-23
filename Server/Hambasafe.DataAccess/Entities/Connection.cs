using System;
using System.ComponentModel.DataAnnotations;
namespace Hambasafe.DataAccess.Entities
{

    public  class Connection
    {
        [Key]
        public int UserId { get; set; }
        public int ConnectionUserId { get; set; }
        public string Relationship { get; set; }
        public DateTime? DateCreated { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
