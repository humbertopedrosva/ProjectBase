using Microsoft.Extensions.DependencyInjection;
using ProjectBase.Infra.Context;

namespace ProjectBase.Api.Configurations
{
    public static class Bootstrapper
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            return services;
        }
    }
}
