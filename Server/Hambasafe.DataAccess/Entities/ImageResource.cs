using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Hambasafe.DataAccess.Entities
{

    public class ImageResource
    {
       
        [Key]
        public int ImageResourceId { get; set; }
        public byte[] ImageData { get; set; }
        public string MimeType { get; set; }

    }
}
