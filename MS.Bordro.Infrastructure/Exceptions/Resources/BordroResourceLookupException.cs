using System;

namespace MS.Bordro.Infrastructure.Exceptions.Resources
{
    public class BordroResourceLookupException : BordroException
    {
        public BordroResourceLookupException(string lookupName, Exception innerException)
            : base("ResourceLookup", string.Format("Resource Lookup Exception on {0}", lookupName), innerException)
        {
        }
    }

}
