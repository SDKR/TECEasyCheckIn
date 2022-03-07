using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(ECADbContext context) : base (context)
        {

        }
    }
}
