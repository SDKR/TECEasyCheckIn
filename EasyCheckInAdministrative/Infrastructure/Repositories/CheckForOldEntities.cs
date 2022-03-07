using Core.DataInterfaces;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CheckForOldEntities : ICheckForOldEntities
    {
        private readonly ECADbContext _context;
        // how old entities can be before being deleted
        private readonly DateTime _studentCheckInRemoveSetting = DateTime.Now.AddDays(-30);
        private readonly DateTime _studentRemoveSetting = DateTime.Now.AddDays(-7);

        public CheckForOldEntities(ECADbContext context)
        {
            _context = context;
        }

        public void DeleteOldEntities(IEnumerable<Student> entities)
        {
            _context.Students.RemoveRange(entities);
        }

        public void DeleteOldEntities(IEnumerable<StudentCheckIn> entities)
        {
            _context.StudentCheckIns.RemoveRange(entities);
        }

        public async Task<List<StudentCheckIn>> GetOldStudentCheckInsEntities()
        {
            return await _context.StudentCheckIns.Where(sc => sc.Date <= _studentCheckInRemoveSetting).ToListAsync();
        }

        public async Task<List<Student>> GetOldStudentEntities()
        {
            return await _context.Students.Where(sc => sc.IsDeleted == true && sc.DeletedOn <= _studentRemoveSetting).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
