using CopaFilmes.WebAPI.Configurations.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CopaFilmes.WebAPI.Configurations
{
    public static class VersioningConfiguration
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(option =>
            {
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });

            services.AddScoped<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        public static void UseVersioning(this IApplicationBuilder app)
        {
            app.UseMvc()
                .UseApiVersioning()
                .UseMvcWithDefaultRoute();
        }
    }
}
