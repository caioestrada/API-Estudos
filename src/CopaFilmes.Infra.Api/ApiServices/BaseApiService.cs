using CopaFilmes.Domain.Entities.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.Api.ApiServices
{
    public class BaseApiService
    {
        private readonly HttpClient _httpClient;

        public BaseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<HttpReturn> Get(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return new HttpReturn { IsSuccess = response.IsSuccessStatusCode, JsonResult = await response.Content.ReadAsStringAsync() };
        }
    }
}
