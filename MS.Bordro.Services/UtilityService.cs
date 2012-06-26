using System.Collections.Generic;
using System.IO;
using MS.Bordro.Domain;
using MS.Bordro.Infrastructure;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Repositories.DB;

namespace MS.Bordro.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly BordroDbContext _dbContext;

        public UtilityService(IBordroDbContext dbContext)
        {
            _dbContext = dbContext as BordroDbContext;
        }

        public void ClearDatabase() {
            ReloadResources.ClearDatabase(_dbContext);
        }

        public IEnumerable<string> ResetDatabaseResources(string configurationDataFilename)
        {
            ReloadResources.Delete(_dbContext);
            var result = ReloadResources.Set(configurationDataFilename, _dbContext);
            ResourceManager.LoadConfigurationDataFromDb(new ConfigurationDataRepositoryDB(_dbContext));
            ResourceManager.LoadResourceFromDb(new ResourceRepositoryDB(_dbContext));
            ResourceManager.LoadResourceLookupFromDb(new ResourceLookupRepositoryDB(_dbContext));
            return result;
        }
    }

}
