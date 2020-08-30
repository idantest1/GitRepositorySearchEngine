using GitRepositoryAPI.Entities;
using GitRepositoryAPI.Models;

namespace GitRepositoryAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(User model);
    }
}