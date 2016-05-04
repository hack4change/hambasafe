using System;

namespace Hambasafe.DataLayer.Entities
{
    public class UserIdentification
    {
        public UserIdentification()
        {
            // Unique identifier for this data file
            Identifier = Guid.NewGuid();
        }

        public int UserId { get; set; }

        public Guid Identifier { get; internal set; }

        public byte[] Data { get; set; }
    }
}
