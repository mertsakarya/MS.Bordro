using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class CompanyRepositoryDB : BaseGuidRepositoryDB<Company>, ICompanyRepositoryDB
    {
        public CompanyRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }
    }
}
