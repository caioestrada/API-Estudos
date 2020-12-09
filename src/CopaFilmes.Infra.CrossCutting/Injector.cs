using CopaFilmes.Application.AppServices.Interfaces;
using CopaFilmes.Application.AppServices.Services;
using CopaFilmes.Domain.Interfaces.ApiServices;
using CopaFilmes.Domain.Interfaces.CacheServices;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.Api.ApiServices;
using CopaFilmes.Infra.Cache.CacheServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CopaFilmes.Infra.CrossCutting
{
    public static class Injector
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            //App
            services.AddScoped<IFilmesAppService, FilmesAppService>();
            services.AddScoped<ICampeonatoAppService, CampeonatoAppService>();

            //Domain
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<ICampeonatoService, CampeonatoService>();

            //Api
            services.AddHttpClient<IFilmeApiService, FilmeApiService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));

            // Cache
            services.AddScoped<ICacheService, CacheService>();
        }
    }
}
