using CopaFilmes.Application.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.WebAPI.IntTest.Controllers.v1
{
    public class FilmesControllerTest : IClassFixture<TestFactory>
    {
        readonly HttpClient _client;

        public FilmesControllerTest(TestFactory testFactory)
        {
            _client = testFactory.CreateClient();
        }

        [Fact]
        public async Task ObterFilmes()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"api/v1/filmes");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task RealizarTorneio()
        {
            // Arrange
            var filmes = new List<FilmeViewModel>
            {
                new FilmeViewModel { Nota = 8.3, Titulo = "Os Incríveis 2" },
                new FilmeViewModel { Nota = 6.7, Titulo = "Jurassic World: Reino Ameaçado" },
                new FilmeViewModel { Nota = 6.3, Titulo = "Oito Mulheres e um Segredo" },
                new FilmeViewModel { Nota = 7.8, Titulo = "Hereditário" },
                new FilmeViewModel { Nota = 8.8, Titulo = "Vingadores: Guerra Infinita" },
                new FilmeViewModel { Nota = 8.1, Titulo = "Deadpool 2" },
                new FilmeViewModel { Nota = 7.2, Titulo = "Han Solo: Uma História Star Wars" },
                new FilmeViewModel { Nota = 7.9, Titulo = "Thor: Ragnarok" }
            };
            var content = new StringContent(JsonSerializer.Serialize(filmes), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"api/v1/filmes/competidores", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task RealizarTorneioComNumeroErradoDeCompetidores()
        {
            // Arrange
            var filmes = new List<FilmeViewModel>
            {
                new FilmeViewModel { Nota = 8.3, Titulo = "Os Incríveis 2" },
                new FilmeViewModel { Nota = 6.7, Titulo = "Jurassic World: Reino Ameaçado" }
            };
            var content = new StringContent(JsonSerializer.Serialize(filmes), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"api/v1/filmes/competidores", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


    }
}
