using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Infrastructure.Exceptions.Web
{
    public class BordroNotAllowedException : BordroException
    {

        public BordroNotAllowedException(User user, string message)
            : base("NotAllowed", message, null)
        {
            User = user;
        }

        public User User { get; set; }
    }

}
