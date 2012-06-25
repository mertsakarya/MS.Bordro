using System;
using System.Collections.Generic;
using MS.Bordro.Enumerations;

namespace MS.Bordro.Interfaces.Services
{
    public interface IResourceService
    {
        string ConfigurationValue(string propertyName);
        string ConfigurationValue(string propertyName, string key, bool mustFind = false);
        string ResourceValue(string resourceName, string language = "");
        string ResourceValue(string propertyName, string key, bool mustFind, string language);

        IDictionary<string, string> GetLookup(string lookupName, string countryCode = "");
        string GetLookupText(string lookupName, string key, string countryCode = "");
        string GetLookupEnumKey(string lookupName, byte value, string language = "");

        bool ContainsKey(string lookupName, string key, string countryCode = "");

        string UrlFriendlyDateTime(DateTime dateTime);
    }
}
