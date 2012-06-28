using MS.Bordro.Domain.Entities;
using MS.Bordro.Infrastructure.Cache;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Services
{
    public class CompanyService : BaseGridRepositoryService<Company>, ICompanyService
    {
        public CompanyService(ICompanyRepositoryDB repository, IBordroGlobalCacheContext globalCacheContext) : base(repository, globalCacheContext) {}
    }
}
