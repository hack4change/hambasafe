using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataAccess.Entities
{

    public class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }
        [Key]
        [Column("EventTypeId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
