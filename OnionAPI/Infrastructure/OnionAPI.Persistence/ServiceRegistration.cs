using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Persistence.Contexts;

namespace OnionAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding DbContext to IoC Container
            services.AddDbContext<OnionAPIDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
