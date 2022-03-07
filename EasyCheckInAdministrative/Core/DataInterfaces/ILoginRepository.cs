using Core.DataInterfaces.Base;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface ILoginRepository : IRepository<Instructor>
    {
        Task<Instructor> LoginCheck(Instructor instructor);
    }
}
