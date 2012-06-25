using System;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Enumerations;

namespace MS.Bordro.Interfaces.Services
{
    public interface IUserService
    {
        bool ValidateUser(string userName, string password);
        User CreateUser(string userName, string password, string email, object passwordQuestion, object passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);
        void UpdateUser(User user);
        User GetUser(string userName, bool userIsOnline = false);
        User GetUser(long id);
        User GetUser(Guid guid);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
