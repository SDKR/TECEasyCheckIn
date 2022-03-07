using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ECADbContext context) : base(context)
        {
        }

        public async Task<Department> GetDepartmentByDepartmentName(string departmentName)
        {
            return await _context.Departments.Where(d => d.Name == departmentName).FirstOrDefaultAsync();
        }
    }
}
