using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1")]
    public class UsersController 
    {
        IMapper Mapper;
        public UsersController( IMapper mapper) 
        {
            Mapper = mapper;
        }

        //[AllowAnonymous]
        //[Route("create-user"), HttpPost]
        //public async Task<HttpResponseMessage> CreateUser(UserModel newUser)
        //{
        //    try
        //    {
        //        //TODO add this 

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception error)
        //    {
        //        return HandleError(error);
        //    }
        //}

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
        public async Task<List<UserModel>> GetUsers(string username)
        {
           
                HambasafeDataContext context = new HambasafeDataContext();

                var users = Mapper.Map<List<User>, List<UserModel>>(context.Users.Where(a => a.FirstNames.ToUpper().Contains(username.ToUpper()) ||
                                                     a.LastName.ToUpper().Contains(username.ToUpper())).ToList());

                return users;
            
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("user"), HttpGet]
        public async Task<UserModel> GetUser(int id)
        {
                HambasafeDataContext context = new HambasafeDataContext();

                var userEntity = context.Users.FirstOrDefault(e => e.Id == id);

                var user = Mapper.Map<UserModel>(userEntity);

                return  user;
            
            
        }
    }
}
