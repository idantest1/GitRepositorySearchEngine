using GitRepositoryAPI.Contexts;
using GitRepositoryAPI.Helpers;
using GitRepositoryAPI.Services;
using GitRepositoryAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitRepositoryAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<GitAPIManagerContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:GitAPIManager"]));
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<FavoritesUsersRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<GitClient>();
            services.AddCors();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
