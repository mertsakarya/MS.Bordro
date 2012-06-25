using System;

namespace MS.Bordro.Infrastructure.Exceptions
{
    public class BordroException : Exception
    {
        public string Id { get; private set; }

        public BordroException(string id, string message, Exception innerException)
            : base(message, innerException)
        {
            Id = id;
        }

        public BordroException(string id, string message)
            : this(id, message, null)
        {
        }
    }
}
