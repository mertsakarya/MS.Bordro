using System.Linq;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class ResourceLookupRepositoryDB : BaseRepositoryDB<ResourceLookup>, IResourceLookupRepository
    {

        public ResourceLookupRepositoryDB(IBordroDbContext context)
            : base(context) { }

        public ResourceLookup[] GetActiveValues() { return DbContext.Set<ResourceLookup>().Where(r => !r.Deleted).OrderBy(r => r.LookupName).OrderBy(r => r.Language).ToArray(); }
    }
}
