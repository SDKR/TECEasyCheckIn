using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface ICheckForOldEntities
    {
        Task<List<Student>> GetOldStudentEntities();
        Task<List<StudentCheckIn>> GetOldStudentCheckInsEntities();
        void DeleteOldEntities(IEnumerable<Student> entities);
        void DeleteOldEntities(IEnumerable<StudentCheckIn> entities);
        Task<bool> SaveAsync();
    }
}
