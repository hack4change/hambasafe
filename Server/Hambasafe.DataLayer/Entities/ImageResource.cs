using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hambasafe.DataLayer.Entities
{

    public class ImageResource
    {
       
        [Key]
        [Column("ImageResourceId")]
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string MimeType { get; set; }

    }
}
