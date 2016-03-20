using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    public class UserModel
    {
        public UserModel(Entities.User user)
        {
            UserId = user.UserId;
            FirstNames = user.FirstNames;
            LastName = user.LastName;
            Gender = user.Gender;
            DateOfBirth = user.DateOfBirth;
            Status = user.Status;
            MobileNumber = user.MobileNumber;
            EmailAddress = user.EmailAddress;
        }

        public UserModel()
        {
        }

        public int UserId { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Status { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}