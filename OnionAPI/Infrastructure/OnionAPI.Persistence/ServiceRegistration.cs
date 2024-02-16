using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Interfaces.Repositories;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Persistence.Contexts;
using OnionAPI.Persistence.Repositories;
using OnionAPI.Persistence.UnitOfWorks;

namespace OnionAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding DbContext to IoC Container
            services.AddDbContext<OnionAPIDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Adding repositories to IoC
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            //Adding UnitOfWork to IoC
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
