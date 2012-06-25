using System;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Enumerations;
using MS.Bordro.Infrastructure.Cache;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryDB _repository;
        private readonly IBordroGlobalCacheContext _bordroGlobalCache;

        public UserService(IUserRepositoryDB repository, IBordroGlobalCacheContext globalCacheContext)
        {
            _repository = repository;
            _bordroGlobalCache = globalCacheContext;
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = _repository.Single(u => u.UserName == userName);
            if (user == null) return false;
            if (user.Password != password) return false;
            return true;
        }

        public User CreateUser(string userName, string password, string email, object passwordQuestion, object passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var existingUser = GetUser(userName);
            if (existingUser != null) { 
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            //existingUser = _repository.Single(p => p.Email == email);
            //if (existingUser != null)
            //{
            //    status = BordroMembershipCreateStatus.DuplicateEmail;
            //    return null;
            //}
            var user = new User {Email = email, Password = password, UserName = userName};
            _repository.Add(user);
            _repository.Save();
            status = MembershipCreateStatus.Success;
            return user;
        }

        public void UpdateUser(User user) { _repository.FullUpdate(user); }


        public User GetUser(long id) { return _repository.Single(u => u.Id == id); }

        public User GetUser(Guid guid) { return _repository.Single(u => u.Guid == guid); }

        public User GetUser(string userName, bool userIsOnline = false)
        {
            var user = _bordroGlobalCache.Get<User>("U:"+userName);
            if (user == null) {
                user = _repository.Single(u => u.UserName == userName);
                _bordroGlobalCache.Add("U:" + userName, user);
            }
            return user;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var user = _repository.Single(u => u.UserName == userName);
            if (user == null) return false;
            if (user.Password != oldPassword) return false;
            user.Password = newPassword;
            _repository.FullUpdate(user);
            _repository.Save();
            return true;
        }
    }
}
