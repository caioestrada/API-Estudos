using Bogus;
using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Domain.Test.Entities
{
    public class FaseEliminatoriaTest
    {
        private readonly List<Filme> _filmes = new List<Filme>
            {
                new Filme { Nota = 8.8, Titulo = "Vingadores: Guerra Infinita" },
                new Filme { Nota = 7.9, Titulo = "Thor: Ragnarok" },
                new Filme { Nota = 8.3, Titulo = "Os Incríveis 2" },
                new Filme { Nota = 6.7, Titulo = "Jurassic World: Reino Ameaçado" },
            };

        [Fact]
        public void Realizar_Partidas_Eliminatorias()
        {
            // Arrange
            var faseEliminatoria = new FaseEliminatoria(_filmes);

            // Act
            var vencedores = faseEliminatoria.RealizarPartidas();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", vencedores[0].Titulo);
            Assert.Equal("Os Incríveis 2", vencedores[1].Titulo);
        }

        [Fact]
        public void Realizar_Partidas_Com_Quantidade_Incorreta()
        {
            // Arrange
            var filmes = new Faker<Filme>()
                .RuleFor(p => p.Nota, p => p.Random.Int(0, 10))
                .RuleFor(p => p.Titulo, p => p.Music.Random.String())
                .Generate(6);

            var faseEliminatoria = new FaseEliminatoria(filmes);

            // Act
            var vencedores = faseEliminatoria.RealizarPartidas();

            // Assert
            Assert.Empty(vencedores);
        }
    }
}
