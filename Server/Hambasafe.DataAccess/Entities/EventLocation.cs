namespace Hambasafe.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public  class EventLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventLocation()
        {
            //this.Events = new HashSet<Event>();
            //this.Events1 = new HashSet<Event>();
        }
        [Key]
        public int EventLocationId { get; set; }
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
