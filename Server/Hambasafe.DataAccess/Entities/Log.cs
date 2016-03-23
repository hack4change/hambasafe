using System.ComponentModel.DataAnnotations;
using System;
namespace Hambasafe.DataAccess.Entities
{
  

    public  class Log
    {
        [Key]
        public int LogId { get; set; }
        public string LogType { get; set; }
        public string LogName { get; set; }
        public string LogDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
