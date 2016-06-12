using System.ComponentModel.DataAnnotations;
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
    public class AttendanceController
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceService attendanceService, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("join-event"), HttpPost]
        public async Task<bool> JoinEvent([FromBody]AttendanceModel attendanceModel)
        {
            ValidateAttendanceModel(attendanceModel);

            var attendanceEntity = _mapper.Map<Attendance>(attendanceModel);

            return await _attendanceService.Join(attendanceEntity);
        }

        [AllowAnonymous]
        [Route("withdraw-event"), HttpPost]
        public async Task<bool> WithdrawEvent([FromBody]AttendanceModel attendanceModel)
        {
            ValidateAttendanceModel(attendanceModel);

            var attendanceEntity = _mapper.Map<Attendance>(attendanceModel);

            return await _attendanceService.Withdraw(attendanceEntity);
        }

        private static void ValidateAttendanceModel(AttendanceModel attendanceModel)
        {
            if (attendanceModel == null)
            {
                throw new ValidationException($"Invalid data for {nameof(attendanceModel)}");
            }

            if (attendanceModel.EventId <= 0)
            {
                throw new ValidationException("EventId is required");
            }

            if (attendanceModel.UserId <= 0)
            {
                throw new ValidationException("UserId is required");
            }
        }
    }
}
