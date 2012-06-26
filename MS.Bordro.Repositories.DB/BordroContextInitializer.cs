using System.Data.Entity;

namespace MS.Bordro.Repositories.DB
{
    public class BordroContextInitializer : DropCreateDatabaseIfModelChanges<BordroDbContext> //CreateDatabaseIfNotExists<BordroDbContext> //DropCreateDatabaseIfModelChanges<BordroDbContext> //DropCreateDatabaseAlways<BordroContext>// DropCreateDatabaseIfModelChanges<BordroContext>
    {
        private readonly string _configurationDataFilename;

        public BordroContextInitializer(string configurationDataFilename)
        {
            _configurationDataFilename = configurationDataFilename;
        }

        protected override void Seed(BordroDbContext dbContext)
        {
            ReloadResources.Set(_configurationDataFilename, dbContext);
        }
    }
}
