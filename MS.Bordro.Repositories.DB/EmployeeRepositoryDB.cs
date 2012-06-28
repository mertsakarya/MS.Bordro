using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class EmployeeRepositoryDB : BaseGuidRepositoryDB<Employee>, IEmployeeRepositoryDB
    {
        public EmployeeRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }
    }
}
