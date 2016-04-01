using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataLayer.Entities
{
    public  class EventLocation
    {
        public EventLocation()
        {
            //this.Events = new HashSet<Event>();
            //this.Events1 = new HashSet<Event>();
        }
        [Key]
        [Column("EventLocationId")]
        public int Id { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Event> Events { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Event> Events1 { get; set; }
    }
}
