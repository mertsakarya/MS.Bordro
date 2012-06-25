using System.Data.Entity;
using MS.Bordro.Repositories.DB;

namespace MS.Bordro.Infrastructure
{
    public class BordroContextInitializer : CreateDatabaseIfNotExists<BordroDbContext> //DropCreateDatabaseIfModelChanges<BordroDbContext> //DropCreateDatabaseAlways<BordroContext>// DropCreateDatabaseIfModelChanges<BordroContext>
    {
        private BordroDbContext _dbContext;
        protected override void Seed(BordroDbContext dbContext)
        {
            _dbContext = dbContext;
            CreateData();
        }

        public void CreateData()
        {
            ReloadResources.Set(_dbContext);
        }

    }


}
