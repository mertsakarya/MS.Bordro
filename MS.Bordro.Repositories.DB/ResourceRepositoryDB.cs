using System.Linq;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class ResourceRepositoryDB : BaseRepositoryDB<Resource>, IResourceRepository
    {

        public ResourceRepositoryDB(IBordroDbContext context) : base(context)
        {
        }

        public Resource[] GetActiveValues()
        {
            return DbContext.Set<Resource>().Where(r => !r.Deleted).ToArray();
        }
    }
}
