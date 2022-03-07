using Core.DataInterfaces;
using Core.Model;
using Core.Model.Enums;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ECADbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetAllByDepartmentNameAsync(string departmentName)
        {
            return await _context.Students.Include(s => s.StudentCheckIns)
                                             .Where(s => s.Department.Name == departmentName).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllByDepartmentIdAsync(Guid departmentId)
        {
            return await _context.Students.Where(s => s.Department.Id == departmentId).ToListAsync();
        }

        public async Task<Student> GetByFullName(string name)
        {
            return await _context.Students.Where(s => (s.FirstName + " " + s.LastName) == name).FirstOrDefaultAsync();
        }

        public async Task<Student> GetByDepartmentAndFullName(Guid departmentId, string name)
        {
            return await _context.Students.Where(s => s.DepartmentId == departmentId && (s.FirstName + " " + s.LastName) == name).FirstOrDefaultAsync();
        }

        public void SoftDelete(Student student)
        {
            student.IsDeleted = true;
            student.DeletedOn = DateTimeOffset.Now;
        }

        public void RemoveSoftDelete(Student student)
        {
            student.IsDeleted = false;
            student.DeletedOn = null;
        }
    }
}
