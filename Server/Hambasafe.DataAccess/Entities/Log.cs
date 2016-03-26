using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{


    public class Log
    {
        [Key]
        [Column("LogId")]
        public int Id { get; set; }
        public string LogType { get; set; }
        public string LogName { get; set; }
        public string LogDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
