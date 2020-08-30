using GitRepositoryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoryAPI.Contexts
{
    public class GitAPIManagerContext : DbContext
    {
        public GitAPIManagerContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoritesUsers> FavoritseUsers { get; set; }
    }
}
