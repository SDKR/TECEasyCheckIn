using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentCheckInRepository : RepositoryBase<StudentCheckIn>, IStudentCheckInRepository
    {
        public StudentCheckInRepository(ECADbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StudentCheckIn>> GetAllForSelectedWeekAsync(DateTime[] selectedWeek)
        {
            return await _context.StudentCheckIns.Where(sc => selectedWeek.Contains(sc.Date)).Include(s => s.Student).ToListAsync();
        }

        public async Task<IEnumerable<StudentCheckIn>> GetAllNonDeletedForSelectedWeekAsync(DateTime[] selectedWeek)
        {
            return await _context.StudentCheckIns.Where(sc => selectedWeek.Contains(sc.Date) && sc.Student.IsDeleted == false).ToListAsync();
        }

        public async Task<StudentCheckIn> GetStudentCheckInByStudentIdAndDate(Guid id, DateTime date)
        {
            return await _context.StudentCheckIns.Where(sc => sc.StudentId == id && sc.Date == date).FirstOrDefaultAsync();

        }

        public Task<IEnumerable<StudentCheckIn>> ManuelStudenLateTooOnTime(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
