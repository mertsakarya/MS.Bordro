using System;

namespace MS.Bordro.Infrastructure.Exceptions.Resources
{
    public class BordroResourceException : BordroException
    {
        public BordroResourceException(string key, string value, Exception innerException)
            : base("Resource", string.Format("Resource Exception on {0} : {1}", key, value), innerException)
        {
        }
    }

}
