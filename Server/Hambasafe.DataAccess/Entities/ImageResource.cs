using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Hambasafe.DataAccess.Entities
{

    public class ImageResource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImageResource()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int ImageResourceId { get; set; }
        public byte[] ImageData { get; set; }
        public string MimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
