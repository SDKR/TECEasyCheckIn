using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class GeneralSettingsRepository : RepositoryBase<GeneralSettings>, IGeneralSettingsRepository
    {
        public GeneralSettingsRepository(ECADbContext context) : base(context)
        {

        }
    }
}

