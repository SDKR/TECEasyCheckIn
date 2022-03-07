using Core.DataInterfaces.Base;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<IEnumerable<Instructor>> GetAllByDepartmentNameAsync(string departmentName);
        void CreateNoneInstructorForDepartment(Guid departmentId);

        Task ChangeToDefaultInstructor(Guid instructorId);
    }
}
