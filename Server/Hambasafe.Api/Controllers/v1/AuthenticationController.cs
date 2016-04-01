using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1")]
    public class AuthenticationController 
    {
        public AuthenticationController() { 
        }

        [AllowAnonymous]
        [Route("register"), HttpGet]
        public async Task<HttpStatusCode> Register(RegisterModel registerModel)
        {
           
                var dataContext = new HambasafeDataContext();

                // Create new user
                var User = new User()
                {
                    FirstNames = registerModel.FirstNames,
                    LastName = registerModel.LastName,
                    Gender = registerModel.Gender,
                    DateOfBirth = registerModel.DateOfBirth,
                    Status = "created",
                    MobileNumber = registerModel.MobileNumber,
                    EmailAddress = registerModel.EmailAddress,
                    DateCreated = new DateTime(),
                    DateLastLogin = new DateTime()
                };

                // Create the token
                var key = Encoding.UTF8.GetBytes(registerModel.Password.ToUpper());
                string hashString;

                //using (var hmac = new HMACSHA256(key))
                //{
                //    var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes());
                //    hashString = Convert.ToBase64String(hash);
                //}

                //return hashString;



                return HttpStatusCode.OK;
            
           
        }
    }
}
