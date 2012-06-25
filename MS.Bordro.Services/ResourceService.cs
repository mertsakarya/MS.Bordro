using System;
using System.Collections.Generic;
using System.Globalization;
using MS.Bordro.Infrastructure;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ResourceManager _resourceManager;

        public ResourceService()
        {
            _resourceManager = ResourceManager.GetInstance();
        }

        public string ConfigurationValue(string propertyName) { return _resourceManager.ConfigurationValue(propertyName); }
        public string ConfigurationValue(string propertyName, string key, bool mustFind = false) { return _resourceManager.ConfigurationValue(propertyName, key, mustFind); }
        public string ResourceValue(string resourceName, string language = "") { return _resourceManager.ResourceValue(resourceName, language); }
        public string ResourceValue(string propertyName, string key, bool mustFind, string language) { return _resourceManager.ResourceValue(propertyName, key, mustFind, language); }
        public IDictionary<string, string> GetLookup(string lookupName, string countryCode = "") { return _resourceManager.GetLookup(lookupName, countryCode); }
        public string GetLookupText(string lookupName, string key, string countryCode = "") { return _resourceManager.GetLookupText(lookupName, key, countryCode); }
        public string GetLookupEnumKey(string lookupName, byte value, string language = "") { return _resourceManager.GetLookupEnumKey(lookupName, value, language); }
        public bool ContainsKey(string lookupName, string key, string countryCode = "") { return _resourceManager.ContainsKey(lookupName, key, countryCode); }

        public string UrlFriendlyDateTime(DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;
            var day = dateTime.Day;
            var hour = dateTime.Hour;
            var minute = dateTime.Minute;
            var second = dateTime.Second;
            return String.Format("{0}{1}{2}{3}{4}{5}",
                                 year,
                                 (month < 10) ? "0" + month : month.ToString(CultureInfo.InvariantCulture),
                                 (day < 10) ? "0" + day : day.ToString(CultureInfo.InvariantCulture),
                                 (hour < 10) ? "0" + hour : hour.ToString(CultureInfo.InvariantCulture),
                                 (minute < 10) ? "0" + minute : minute.ToString(CultureInfo.InvariantCulture),
                                 (second < 10) ? "0" + second : second.ToString(CultureInfo.InvariantCulture)
                );
        }
    }

}
