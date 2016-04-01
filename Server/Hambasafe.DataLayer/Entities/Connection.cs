using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataLayer.Entities
{

    public  class Connection
    {
        [Key]
        public int UserId { get; set; }
        public int ConnectionUserId { get; set; }
        public string Relationship { get; set; }
        public DateTime? DateCreated { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ConnectionUserId")]
        public virtual User ConnectionUser { get; set; }
    }
}
