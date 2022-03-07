using Core.DataInterfaces.Base;
using Core.Model;
using Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllByDepartmentNameAsync(string departmentName);
        Task<IEnumerable<Student>> GetAllByDepartmentIdAsync(Guid departmentId);
        Task<Student> GetByFullName(string name);
        Task<Student> GetByDepartmentAndFullName(Guid departmentId, string name);
        void SoftDelete(Student student);
        void RemoveSoftDelete(Student student);
    }
}
