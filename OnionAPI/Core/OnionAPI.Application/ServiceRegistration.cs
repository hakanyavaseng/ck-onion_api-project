using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Behaviours;
using OnionAPI.Application.Exceptions;
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

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));

        }
    }
}
