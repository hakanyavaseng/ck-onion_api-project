using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Interfaces.AutoMapper;
using OnionAPI.Mapper.AutoMapper;

namespace OnionAPI.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
