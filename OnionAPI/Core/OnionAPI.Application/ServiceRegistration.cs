using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
