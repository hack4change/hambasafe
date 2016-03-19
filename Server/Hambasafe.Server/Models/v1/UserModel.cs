using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hambasafe.Server.Models.v1
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string IdentityDocumentUrl { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Status { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}