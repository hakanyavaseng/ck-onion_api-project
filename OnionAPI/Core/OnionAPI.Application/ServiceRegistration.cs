using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Bases;
using OnionAPI.Application.Behaviours;
using OnionAPI.Application.Exceptions;
using OnionAPI.Application.Interfaces.RedisCache;
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

            services.AddTransient<ExceptionMiddleware>(); //Adding global exception handler middleware to IoC

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Adding fluent validation to IoC

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>)); // Fluent validation pipeline behaviour.

            services.AddRulesFromAssemblyContaining(Assembly.GetExecutingAssembly(), typeof(BaseRules)); // Call custom rule class and add to IoC

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehaviour<,>)); // Add redis pipeline behavior

        }

        #region BaseRule static class which helps to add all rules in one time to Ioc
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type != t).ToList();

            foreach (var t in types)
            {
                services.AddTransient(t);
            }
            return services;

        }
        #endregion
    }
}
