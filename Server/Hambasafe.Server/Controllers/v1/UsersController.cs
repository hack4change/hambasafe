using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Models.v1;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<HttpResponseMessage> GetAllUsers()
        {
            try
            {
                var users = new UserModel[]
                {
                    new UserModel
                    {
                        UserId = 1,
                        FirstNames = "Foo",
                        LastName = "Bar",
                        DateOfBirth = DateTime.Now.AddYears(-21),
                        EmailAddress = "Foo@Bar.co.za",
                        Gender = "M",
                        IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                        MobileNumber = "123456789",
                        ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                        Status = "Verified"
                    },
                    new UserModel
                    {
                        UserId = 2,
                        FirstNames = "Hum",
                        LastName = "Bug",
                        DateOfBirth = DateTime.Now.AddYears(-75),
                        EmailAddress = "Hum@Bug.co.za",
                        Gender = "M",
                        IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                        MobileNumber = "987654321",
                        ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                        Status = "Unverified"
                    }
                };

                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<HttpResponseMessage> GetUsers(string username)
        {
            try
            {
                var users = new UserModel[]
                {
                    new UserModel
                    {
                        UserId = 1,
                        FirstNames = $"Foo{username}",
                        LastName = "Bar",
                        DateOfBirth = DateTime.Now.AddYears(-21),
                        EmailAddress = "Foo@Bar.co.za",
                        Gender = "M",
                        IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                        MobileNumber = "123456789",
                        ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                        Status = "Verified"
                    },
                    new UserModel
                    {
                        UserId = 2,
                        FirstNames = "Hum",
                        LastName = $"Bug{username}",
                        DateOfBirth = DateTime.Now.AddYears(-75),
                        EmailAddress = "Hum@Bug.co.za",
                        Gender = "M",
                        IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                        MobileNumber = "987654321",
                        ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                        Status = "Unverified"
                    }
                };

                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("user"), HttpGet]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            try
            {
                var user = new UserModel
                {
                    UserId = id,
                    FirstNames = "Foo",
                    LastName = "Bar",
                    DateOfBirth = DateTime.Now.AddYears(-21),
                    EmailAddress = "Foo@Bar.co.za",
                    Gender = "M",
                    IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                    MobileNumber = "123456789",
                    ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                    Status = "Verified"
                };

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("profile"), HttpGet]
        public async Task<HttpResponseMessage> GetProfile(int id)
        {
            try
            {
                var user = new UserModel
                {
                    UserId = id,
                    FirstNames = "Foo",
                    LastName = "Bar",
                    DateOfBirth = DateTime.Now.AddYears(-21),
                    EmailAddress = "Foo@Bar.co.za",
                    Gender = "M",
                    IdentityDocumentUrl = "http://www.google.com?IdentityDocument",
                    MobileNumber = "123456789",
                    ProfilePictureUrl = "http://www.google.com?ProfilePicture",
                    Status = "Verified"
                };

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
