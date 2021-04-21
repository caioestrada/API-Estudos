using CopaFilmes.Application.AppServices.Interfaces;
using CopaFilmes.Application.ViewModels;
using CopaFilmes.WebAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.WebAPI.UnitTest.Controllers.v1
{
    public class FilmesControllerTest
    {
        private readonly Mock<IFilmesAppService> _filmeAppService = new Mock<IFilmesAppService>();
        private readonly Mock<ICampeonatoAppService> _campeonatoAppService = new Mock<ICampeonatoAppService>();

        [Fact]
        public async Task ObterFilmes()
        {
            // Arrange
            var filmes = new List<FilmeViewModel> { new FilmeViewModel(), new FilmeViewModel(), new FilmeViewModel() };
            _filmeAppService.Setup(project => project.ObterTodos()).Returns(Task.FromResult(filmes));
            var filmesController = new FilmesController(_filmeAppService.Object, _campeonatoAppService.Object);

            // Act
            var todosFilmes = await filmesController.ObterTodos();
            var result = todosFilmes.Result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ObterFilmesRetornoVazio()
        {
            // Arrange
            var filmes = new List<FilmeViewModel>();
            _filmeAppService.Setup(project => project.ObterTodos()).Returns(Task.FromResult(filmes));
            var filmesController = new FilmesController(_filmeAppService.Object, _campeonatoAppService.Object);

            // Act
            var todosFilmes = await filmesController.ObterTodos();
            var result = todosFilmes.Result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task ObterFilmesExcecao()
        {
            // Arrange
            List<FilmeViewModel> filmes = null;
            _filmeAppService.Setup(project => project.ObterTodos()).Returns(Task.FromResult(filmes));
            var filmesController = new FilmesController(_filmeAppService.Object, _campeonatoAppService.Object);

            // Act
            var todosFilmes = await filmesController.ObterTodos();
            var result = todosFilmes.Result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void RealizarTorneio()
        {
            // Arrange
            var partida = new PartidaViewModel { 
                Vencedor = new FilmeViewModel { Id = "1", Titulo = "Titulo Filme Vencedor", Nota = 10, Ano = 2002 },
                Derrotado = new FilmeViewModel { Id = "2", Titulo = "Titulo Filme Derrotado", Nota = 9, Ano = 2005 }
            };
            _campeonatoAppService.Setup(project => project.RealizarTorneio(It.IsAny<List<FilmeViewModel>>())).Returns(partida);
            var filmesController = new FilmesController(_filmeAppService.Object, _campeonatoAppService.Object);

            // Act
            var resultadoDoCampeonato = filmesController.RelizarCampeonato(It.IsAny<List<FilmeViewModel>>());
            var result = resultadoDoCampeonato.Result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RealizarTorneioComCompetidoresErrados()
        {
            // Arrange
            _campeonatoAppService.Setup(project => project.RealizarTorneio(It.IsAny<List<FilmeViewModel>>())).Returns(new PartidaViewModel());
            var filmesController = new FilmesController(_filmeAppService.Object, _campeonatoAppService.Object);

            // Act
            var resultadoDoCampeonato = filmesController.RelizarCampeonato(It.IsAny<List<FilmeViewModel>>());
            var result = resultadoDoCampeonato.Result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }
    }
}
