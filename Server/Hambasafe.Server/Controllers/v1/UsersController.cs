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
using AutoMapper;
using System.Collections.Generic;
using Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class UsersController : ApiControllerBase
    {
        IMapper Mapper;
        public UsersController(IConfigurationService configuration, ITableStorageService tableStorage, IMapper mapper) :
            base(configuration, tableStorage)
        {
            Mapper = mapper;
        }

        [AllowAnonymous]
        [Route("create-user"), HttpPost]
        public async Task<HttpResponseMessage> CreateUser(UserModel newUser)
        {
            try
            {
                //TODO add this 

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
        public List<UserModel> GetAllUsers()
        {
            using (var context = new HambasafeDataContext())
            {
                return Mapper.Map<List<User>, List<UserModel>>(context.Users.ToList());

            }
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("users-by-name"), HttpGet]
        public async Task<HttpResponseMessage> GetUsers(string username)
        {
            try
            {
                HambasafeDataContext context = new HambasafeDataContext();

                var users = Mapper.Map<List<User>, List<UserModel>>(context.Users.Where(a => a.FirstNames.ToUpper().Contains(username.ToUpper()) ||
                                                     a.LastName.ToUpper().Contains(username.ToUpper())).ToList());

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
                HambasafeDataContext context = new HambasafeDataContext();

                var userEntity = context.Users.Where(e => e.Id == id)
                                              .FirstOrDefault();

                if (userEntity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"User was not found for id:{id}");
                }

                var user = Mapper.Map<UserModel>(userEntity);

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
