using System.Data.Entity;
using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Repositories.DB
{
    public interface IBordroDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<User> Users { get; set; }
    }
}
