using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class CompanyLocationRepositoryDB : BaseDetailGuidRepositoryDB<CompanyLocation>, ICompanyLocationRepositoryDB
    {
        public CompanyLocationRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }

        public override IList<CompanyLocation> GetAllByKey<TKey>(long id, out int total, int pageNo, int pageSize, Expression<Func<CompanyLocation, TKey>> orderByClause, bool @ascending)
        {
            return Query(p => p.CompanyId == id, pageNo, pageSize, out total, orderByClause, @ascending);
        }
    }
}
