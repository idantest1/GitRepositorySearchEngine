using GitRepositoryAPI.Contexts;
using System.Linq;

namespace GitRepositoryAPI.Repositories
{
    public class FavoritesUsersRepository
    {
        readonly GitAPIManagerContext _gitAPIManager;
        public FavoritesUsersRepository(GitAPIManagerContext gitAPIManager)
        {
            _gitAPIManager = gitAPIManager;
        }

        public void AddFavorites(int UserId, Models.AddFavoritesRequest addFavoritesRequest)
        {
            foreach (var favorit in addFavoritesRequest.Favorites)
            {
                _gitAPIManager.FavoritseUsers.Add(new Entities.FavoritesUsers()
                {
                    UserId = UserId,
                    Favorite = favorit
                });
                _gitAPIManager.SaveChanges();
            }
        }

        public string[] GetFavorites(int userId)
        {
           return _gitAPIManager.FavoritseUsers
                                        .Where(x => x.UserId == userId)
                                        .Select(x=>x.Favorite).ToArray();
        }


    }
}
