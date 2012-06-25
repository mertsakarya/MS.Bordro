using System.Collections.Generic;
using MS.Bordro.Repositories.DB;

namespace MS.Bordro.Infrastructure
{
    public static class ReloadResources
    {
        public static void Reset(BordroDbContext dbContext)
        {
            Delete(dbContext);
            Set(dbContext);
        }

        public static List<string> Set(BordroDbContext dbContext)
        {
            var parser = new ConfigParser(dbContext);
            return parser.Parse();
        }

        public static void Delete(BordroDbContext dbContext)
        {
            foreach (var tableName in new [] {"Resources", "ConfigurationDatas", "ResourceLookups" }) {
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tableName + "]");
            }
        }

        public static void ClearDatabase(BordroDbContext dbContext)
        {

            foreach (var tableName in new[] { "CountriesToVisits", "Conversations", "LanguagesSpokens", "SearchingFors", "Visits", "PhotoBackups", "Photos", "States" }) {

                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tableName + "]");
            }
            dbContext.Database.ExecuteSqlCommand("DELETE FROM [Profiles]");
            dbContext.Database.ExecuteSqlCommand("DELETE FROM [Users]");
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT ([Users], RESEED, 1)");
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT ([Profiles], RESEED, 1)");
        }
    }
}
