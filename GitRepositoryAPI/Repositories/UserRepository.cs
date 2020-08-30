using GitRepositoryAPI.Contexts;
using GitRepositoryAPI.Entities;
using GitRepositoryAPI.Helpers;
using System;
using System.Linq;

namespace GitRepositoryAPI.Repositories
{
    public class UserRepository
    {
        readonly GitAPIManagerContext _gitAPIManager;
        public UserRepository(GitAPIManagerContext gitAPIManager)
        {
            _gitAPIManager = gitAPIManager;
        }

        public User CreateUser(string UserName, string Password)
        {
            if (_gitAPIManager.Users.FirstOrDefault(x => x.UserName == UserName) != null)
                throw new Exception("User already exist");

            var user = new User { UserName = UserName, Password = HashHelper.ComputeHash(Password) };
            _gitAPIManager.Users.Add(user);
            _gitAPIManager.SaveChanges();
            return user;
        }

        public User GetUser(string userName, string password)
        {
            var user = _gitAPIManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
                return null;
            if (HashHelper.IsValidHash(user.Password, password))
                return user;
            return null;
        }

        public User GetById(int userId)
        {
            return _gitAPIManager.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
