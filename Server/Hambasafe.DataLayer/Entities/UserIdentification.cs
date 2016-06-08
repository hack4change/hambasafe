using System;

namespace Hambasafe.DataLayer.Entities
{
    public class UserIdentification
    {
        private string _base64Data;
        private byte[] _byteData;

        public UserIdentification()
        {
            // Unique identifier for this data file
            Identifier = Guid.NewGuid();
        }

        public int UserId { get; set; }

        public Guid Identifier { get; internal set; }

        public string FileExtension { get; set; }

        public string Base64Data {
            get
            {
                if (_base64Data == null && _byteData != null && _byteData.Length > 0)
                {
                    _base64Data = Convert.ToBase64String(_byteData);
                }

                return _base64Data;
            }
            set
            {
                _base64Data = value;

                _byteData = Convert.FromBase64String(_base64Data);
            }
        }

        public byte[] ByteData
        {
            get
            {
                if ((_byteData == null || _byteData.Length == 0) && !string.IsNullOrEmpty(_base64Data))
                {
                    _byteData = Convert.FromBase64String(_base64Data);
                }

                return _byteData;
            }
            set
            {
                _byteData = value;

                _base64Data = Convert.ToBase64String(_byteData);
            }
        }
    }
}
