using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hambasafe.DataAccess.Entities
{

    public class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }
        [Key]
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
