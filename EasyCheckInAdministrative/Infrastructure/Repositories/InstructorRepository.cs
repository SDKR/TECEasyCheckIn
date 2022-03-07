using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository, ILoginRepository
    {
        public InstructorRepository(ECADbContext context) : base(context)
        {
        }

        public void CreateNoneInstructorForDepartment(Guid departmentId)
        {
            _context.Add(
                new Instructor()
                {
                    Id = Guid.NewGuid(),
                    Initials = "Ingen",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = departmentId
                }
            );
        }

        public async Task<IEnumerable<Instructor>> GetAllByDepartmentNameAsync(string departmentName)
        {
            return await _context.Instructors.Where(i => i.Department.Name == departmentName).OrderBy(i => i.Initials).ToListAsync();
        }

        public async Task<Instructor> LoginCheck(Instructor instructor)
        {
            var respons =  await _context.Instructors.FirstOrDefaultAsync(i => i.Initials.Equals(instructor.Initials) && i.Password.Equals(instructor.Password));

            if (respons == null)
            {
                return null;
            }
            else if (respons.Initials == instructor.Initials && respons.Password == instructor.Password)
            {
                return respons;
            }
            else
            {
                return null;
            }

        }

        public async Task ChangeToDefaultInstructor(Guid instructorId)
        {
            var StudentsToChange =  _context.Students.Where(x => x.InstructorId == instructorId);
            Instructor IngenId = _context.Instructors.Where(x => x.Initials == "Ingen").FirstOrDefault<Instructor>();
            await StudentsToChange.ForEachAsync(a => a.InstructorId = IngenId.Id);
            _context.SaveChanges();
            return ;
        }

    }
}
