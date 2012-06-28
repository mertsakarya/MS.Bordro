using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class VehicleRepositoryDB : BaseGuidRepositoryDB<Vehicle>, IVehicleRepositoryDB
    {
        public VehicleRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }
    }
}
