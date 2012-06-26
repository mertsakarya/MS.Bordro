using System.Data.Entity;
using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Repositories.DB
{
    public interface IBordroDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<CompanyLocation> CompanyLocations { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<RouteInformation> RouteInformations { get; set; }
        DbSet<SpecialDay> SpecialDays { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<WorkRequest> WorkRequest { get; set; }

        DbSet<ConfigurationData> ConfigurationDatas { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<ResourceLookup> ResourceLookups { get; set; }
    }
}
