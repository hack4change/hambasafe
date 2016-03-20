using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Hambasafe.Server.Models.v1;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using Entities = Hambasafe.DataAccess.Entities;

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
                Entities.HambasafeDataContext context = new Entities.HambasafeDataContext();

                var users = context.Users.Select(e => new UserModel(e)).ToArray();

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
                Entities.HambasafeDataContext context = new Entities.HambasafeDataContext();

                var users = context.Users.Where(a=>
                                a.FirstNames.ToUpper().Contains(username.ToUpper()) 
                                || a.LastName.ToUpper().Contains(username.ToUpper())).Select(e => new UserModel(e)).ToArray();

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
                Entities.HambasafeDataContext context = new Entities.HambasafeDataContext();

                UserModel user = new UserModel(context.Users.Where(e => e.UserId == id) as Entities.User);

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
                Entities.HambasafeDataContext context = new Entities.HambasafeDataContext();

                UserModel user = new UserModel(context.Users.Where(e => e.UserId == id) as Entities.User);

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
