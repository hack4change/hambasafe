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
        [Route("createuser"), HttpPost]
        public async Task<HttpResponseMessage> CreateUser(UserModel newUser)
        {
            try
            {
                if (newUser.UserId.HasValue)
                    throw (new ApplicationException("Cannot create a user who already has an UserId assigned."));

                using (var dataContext = new Entities.HambasafeDataContext())
                {
                    var user = newUser.MapToUserEntity();
                    dataContext.Users.Add(user);
                    dataContext.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<HttpResponseMessage> GetAllUsers()
        {
            try
            {
                using (var dataContext = new Entities.HambasafeDataContext())
                {
                    var users = dataContext.Users.ToList().Select(e => UserModel.Create(e));
                    return Request.CreateResponse(HttpStatusCode.OK, users);
                }
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<HttpResponseMessage> GetUsers(string username)
        {
            try
            {
                var dataContext = new Entities.HambasafeDataContext();
                var users = dataContext.Users.ToList().Where(a=>
                                a.FirstNames.ToUpper().Contains(username.ToUpper()) 
                                || a.LastName.ToUpper().Contains(username.ToUpper())).Select(e => UserModel.Create(e));

                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("user"), HttpGet]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            try
            {
                var dataContext = new Entities.HambasafeDataContext();
                var user = UserModel.Create(dataContext.Users.ToList().Where(e => e.UserId == id).First());

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("profile"), HttpGet]
        public async Task<HttpResponseMessage> GetProfile(int id)
        {
            try
            {
                var dataContext = new Entities.HambasafeDataContext();
                var user = UserModel.Create(dataContext.Users.ToList().Where(e => e.UserId == id).First());

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
