using System.Collections.Generic;

namespace MS.Bordro.Interfaces.Services
{
    public interface IUtilityService
    {
        void ClearDatabase();
        IEnumerable<string> ResetDatabaseResources(string configurationDataFilename);
    }
}
