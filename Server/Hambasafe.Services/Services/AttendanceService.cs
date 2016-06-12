using System;
using System.Linq;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.Services.Exceptions;
using Microsoft.Data.Entity;

namespace Hambasafe.Services.Services
{
    public interface IAttendanceService
    {
        Task<bool> Join(Attendance attendance);

        Task<bool> Withdraw(Attendance attendance);
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _attendanceRepository;
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<User> _userRepository;

        public AttendanceService(IRepository<Attendance> attendanceRepository, IRepository<Event> eventRepository, IRepository<User> userRepository)
        {
            _attendanceRepository = attendanceRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Join(Attendance attendance)
        {
            try
            {
                // Check if the event and user exists
                await ValidateAttendanceDetails(attendance);

                // Check if this attendance already exists
                if (await _attendanceRepository.FindAll(a => a.EventId == attendance.EventId && a.UserId == attendance.UserId)
                                               .AnyAsync())
                {
                    return false;
                }

                attendance.HasAttended = false;
                attendance.DateCreated = DateTime.UtcNow;

                var result = await _attendanceRepository.Add(attendance);

                if (result != 1)
                {
                    throw new DataException($"Expected to add 1 attendance, but instead added {result}");
                }

                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while adding an attendance", ex.InnerException);
            }
        }

        public async Task<bool> Withdraw(Attendance attendance)
        {
            try
            {
                // There may be more than one attendance
                var attendances = await _attendanceRepository.FindAll(a => a.EventId == attendance.EventId && a.UserId == attendance.UserId)
                                                             .ToArrayAsync();

                // Cannot delete an attendance once you have attended the event
                if (attendances.Any(a => a.HasAttended.HasValue && a.HasAttended.Value))
                {
                    throw new DataException("Cannot withdraw from an event that has already been attended");
                }

                var result = await _attendanceRepository.DeleteRange(attendances);

                if (result != attendances.Length)
                {
                    throw new DataException($"Expected to delete {attendances.Length} attendance, but instead deleted {result}");
                }

                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Error occured while removing an attendance", ex.InnerException);
            }
        }

        private async Task ValidateAttendanceDetails(Attendance attendance)
        {
            if (!await _eventRepository.FindAll(e => e.Id == attendance.EventId).AnyAsync())
            {
                throw new DataException($"Event does not exist for Id:{attendance.EventId}");
            }

            if (!await _userRepository.FindAll(u => u.Id == attendance.UserId).AnyAsync())
            {
                throw new DataException($"User does not exist for Id:{attendance.UserId}");
            }
        }
    }
}
