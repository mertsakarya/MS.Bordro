using System.Data.Entity;
using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Repositories.DB
{

    public class BordroDbContext : DbContext, IBordroDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Profile>()
        //                .HasMany(u => u.SentMessages)
        //                .WithRequired(ul => ul.From)
        //                .HasForeignKey(ul => ul.FromId).WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Profile>()
        //                .HasMany(u => u.RecievedMessages)
        //                .WithRequired(ul => ul.To)
        //                .HasForeignKey(ul => ul.ToId)
        //                .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Profile>()
        //                .HasMany(u => u.Visited)
        //                .WithRequired(ul => ul.Profile)
        //                .HasForeignKey(ul => ul.ProfileId)
        //                .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Profile>()
        //                .HasMany(u => u.WhoVisited)
        //                .WithRequired(ul => ul.VisitorProfile)
        //                .HasForeignKey(ul => ul.VisitorProfileId)
        //                .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Profile>().HasRequired(x => x.User); //.WithOptional(s=>s.Profile); //.Map(x => x.MapKey("UserId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
