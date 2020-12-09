using CopaFilmes.Domain.Entities.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.WebAPI.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceConfiguration = new ServiceConfiguration();

            configuration.Bind(serviceConfiguration);
            services.AddSingleton(serviceConfiguration);
        }
    }
}
