using System.Linq;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class ConfigurationDataRepositoryDB : BaseRepositoryDB<ConfigurationData>, IConfigurationDataRepository
    {

        public ConfigurationDataRepositoryDB(IBordroDbContext context)
            : base(context)
        {
        }

        public ConfigurationData[] GetActiveValues()
        {
            return DbContext.Set<ConfigurationData>().Where(r => !r.Deleted).ToArray();
        }
    }

}
