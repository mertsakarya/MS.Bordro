using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class WorkRequestRepositoryDB : BaseGuidRepositoryDB<WorkRequest>, IWorkRequestRepositoryDB
    {
        public WorkRequestRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }
    }
}
