using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Entities.Configurations;
using CopaFilmes.Domain.Interfaces.ApiServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.Api.ApiServices
{
    public class FilmeApiService : BaseApiService, IFilmeApiService
    {
        private readonly CopaFilmeConfiguration _copaFilmeConfiguration;

        public FilmeApiService(ServiceConfiguration serviceConfiguration, HttpClient httpClient) : base(httpClient)
        {
            _copaFilmeConfiguration = serviceConfiguration.CopaFilmeConfiguration;
        }

        public async Task<List<Filme>> ObterTodos()
        {
            var httpReturn = await Get($"{_copaFilmeConfiguration.Url}/api/filmes");

            if (!httpReturn.IsSuccess)
                return new List<Filme>();

            return JsonSerializer.Deserialize<List<Filme>>(httpReturn.JsonResult);
        }
    }
}
