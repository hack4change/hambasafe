using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class UsersController
    {
        IMapper Mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            Mapper = mapper;
            _userService = userService;
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
        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userService.FindAll();
            return Mapper.Map<List<User>, List<UserModel>>(users);


        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("users-by-name"), HttpGet]
        public async Task<List<UserModel>> GetUsers(string username)
        {
            var users = await _userService.FindAllByUsername(username);
            return Mapper.Map<List<User>, List<UserModel>>(users);
        }

        /// <summary>
        /// Implemented
        /// </summary>
        [AllowAnonymous]
        [Route("user"), HttpGet]
        public async Task<UserModel> GetUser(int id)
        {
            var userEntity = await _userService.FindById(id);
            return Mapper.Map<UserModel>(userEntity);
        }
    }
}
