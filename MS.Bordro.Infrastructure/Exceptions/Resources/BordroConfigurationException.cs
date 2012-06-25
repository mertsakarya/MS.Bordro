using System;

namespace MS.Bordro.Infrastructure.Exceptions.Resources
{
    public class BordroConfigurationException : BordroException
    {
        public BordroConfigurationException(string key, string value, Exception innerException)
            : base("Configuration", string.Format("Configuration Exception on {0} : {1}", key, value), innerException)
        {
        }
    }

}
