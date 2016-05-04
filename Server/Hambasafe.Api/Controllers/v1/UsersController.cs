using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("create-user"), HttpPost]
        public async Task<int> CreateUser([FromBody]UserModel userModel)
        {
            ValidateUserModel(userModel);

            var userEntity = _mapper.Map<User>(userModel);

            return await _userService.Add(userEntity);
        }

        [AllowAnonymous]
        [Route("update-user"), HttpPost]
        public async Task<int> UpdateUser([FromBody]UserModel userModel)
        {
            ValidateUserModel(userModel);

            var userEntity = _mapper.Map<User>(userModel);

            return await _userService.Update(userEntity);
        }

        [AllowAnonymous]
        [Route("upload-identification"), HttpPost]
        public async Task<int> UploadIdentification([FromBody]UserIdentificationModel userIdentificationModel)
        {
            ValidateUserIdentificationModel(userIdentificationModel);

            var userIdentificationEntity = _mapper.Map<UserIdentification>(userIdentificationModel);

            return await _userService.SaveIdentification(userIdentificationEntity);
        }

        [AllowAnonymous]
        [Route("users"), HttpGet]
        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userService.FindAll();

            return _mapper.Map<List<User>, List<UserModel>>(users);
        }

        [AllowAnonymous]
        [Route("users-by-name"), HttpGet]
        public async Task<List<UserModel>> GetUsersByName([FromQuery]string name)
        {
            var users = await _userService.FindAllByName(name);

            return _mapper.Map<List<User>, List<UserModel>>(users);
        }
        
        [AllowAnonymous]
        [Route("user"), HttpGet]
        public async Task<UserModel> GetUser([FromQuery]int id, [FromQuery]string emailAddress)
        {
            User userEntity;
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                userEntity = await _userService.FindByUserName(emailAddress);
            }
            else
            {
                userEntity = await _userService.FindById(id);
            }
            
            return _mapper.Map<UserModel>(userEntity);
        }

        private static void ValidateUserModel(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ValidationException($"Invalid data for {nameof(userModel)}");
            }

            if (string.IsNullOrWhiteSpace(userModel.FirstNames))
            {
                throw new ValidationException("First Name is required");
            }

            if (string.IsNullOrWhiteSpace(userModel.LastName))
            {
                throw new ValidationException("Last Name is required");
            }

            if (string.IsNullOrWhiteSpace(userModel.EmailAddress))
            {
                throw new ValidationException("Email Address is required");
            }

            if (string.IsNullOrWhiteSpace(userModel.MobileNumber))
            {
                throw new ValidationException("Mobile Number is required");
            }

            if (userModel.DateOfBirth <= SqlDateTime.MinValue)
            {
                throw new ValidationException("Invalid Date of Birth");
            }
        }

        private static void ValidateUserIdentificationModel(UserIdentificationModel userIdentificationModel)
        {
            if (userIdentificationModel == null)
            {
                throw new ValidationException($"Invalid data for {nameof(userIdentificationModel)}");
            }

            if (userIdentificationModel.UserId == default(int) || userIdentificationModel.UserId <= 0)
            {
                throw new ValidationException("Invalid UserId");
            }

            ////if (userIdentificationModel.Data == null || userIdentificationModel.Data.Length == 0)
            ////{
            ////    throw new ValidationException("Invalid Data");
            ////}
        }
    }
}
