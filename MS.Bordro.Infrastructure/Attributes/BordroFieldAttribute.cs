using System;
using System.Web.Mvc;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BordroFieldAttribute : Attribute
    {
        private static readonly IResourceService ResourceService = DependencyResolver.Current.GetService<IResourceService>();

        public BordroFieldAttribute(string propertyName) { PropertyName = propertyName; }
        public string PropertyName { get; private set; }
        public string GetFromResource(string key, bool mustFind = false, string language = "")
        {
            return ResourceService.ResourceValue(PropertyName, key, mustFind, language);
        }

        public string GetFromConfiguration(string key, bool mustFind = false)
        {
            return ResourceService.ConfigurationValue(PropertyName, key, mustFind);
        }
    }
}
