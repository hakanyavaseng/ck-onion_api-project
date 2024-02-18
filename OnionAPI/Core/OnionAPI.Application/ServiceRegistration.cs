using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Exceptions;
using System.Reflection;

namespace OnionAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
