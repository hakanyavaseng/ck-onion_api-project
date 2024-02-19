using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Interfaces.Repositories;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities.Identity;
using OnionAPI.Persistence.Contexts;
using OnionAPI.Persistence.Repositories;
using OnionAPI.Persistence.UnitOfWorks;
using System;

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

            //Adding identity to IoC
            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<OnionAPIDbContext>();

 
        }

    }
}
