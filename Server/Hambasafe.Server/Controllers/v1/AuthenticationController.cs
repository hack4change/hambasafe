using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Models.v1;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Hambasafe.DataAccess.Entities;
using System.Text;
using System.Security.Cryptography;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class AuthenticationController : ApiControllerBase
    {
        public AuthenticationController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("register"), HttpGet]
        public async Task<HttpResponseMessage> Register(RegisterModel registerModel)
        {
            try
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



                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
