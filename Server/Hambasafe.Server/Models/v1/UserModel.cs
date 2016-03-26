using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    public class UserModel
    {
       

        public UserModel()
        {
        }

        public int UserId { get; set; }

        public string Token { get; set; }

        public string ProfilePicture { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Status { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}