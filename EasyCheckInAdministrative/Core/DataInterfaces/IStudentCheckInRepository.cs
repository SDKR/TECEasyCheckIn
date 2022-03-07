using Core.DataInterfaces.Base;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface IStudentCheckInRepository : IRepository<StudentCheckIn>
    {
        Task<StudentCheckIn> GetStudentCheckInByStudentIdAndDate(Guid id, DateTime date);
        Task<IEnumerable<StudentCheckIn>> GetAllForSelectedWeekAsync(DateTime[] selectedWeek);
        Task<IEnumerable<StudentCheckIn>> GetAllNonDeletedForSelectedWeekAsync(DateTime[] selectedWeek);
        Task<IEnumerable<StudentCheckIn>> ManuelStudenLateTooOnTime(Student student);
    }
}
