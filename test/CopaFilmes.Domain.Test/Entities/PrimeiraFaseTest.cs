using Bogus;
using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Domain.Test.Entities
{
    public class PrimeiraFaseTest
    {
        private readonly List<Filme> _filmes = new List<Filme>
            {
                new Filme { Nota = 8.3, Titulo = "Os Incríveis 2" },
                new Filme { Nota = 6.7, Titulo = "Jurassic World: Reino Ameaçado" },
                new Filme { Nota = 6.3, Titulo = "Oito Mulheres e um Segredo" },
                new Filme { Nota = 7.8, Titulo = "Hereditário" },
                new Filme { Nota = 8.8, Titulo = "Vingadores: Guerra Infinita" },
                new Filme { Nota = 8.1, Titulo = "Deadpool 2" },
                new Filme { Nota = 7.2, Titulo = "Han Solo: Uma História Star Wars" },
                new Filme { Nota = 7.9, Titulo = "Thor: Ragnarok" }
            };

        [Fact]
        public void Realizar_Ordenacao_Dos_Filmes()
        {
            // Arrange
            var primeiraFase = new PrimeiraFase(_filmes);

            // Act
            primeiraFase.OrdenarFilmesPorOrdemAlfabetica();

            // Assert
            Assert.Equal("Deadpool 2", primeiraFase.Filmes[0].Titulo);
            Assert.Equal("Han Solo: Uma História Star Wars", primeiraFase.Filmes[1].Titulo);
            Assert.Equal("Hereditário", primeiraFase.Filmes[2].Titulo);
            Assert.Equal("Jurassic World: Reino Ameaçado", primeiraFase.Filmes[3].Titulo);
            Assert.Equal("Oito Mulheres e um Segredo", primeiraFase.Filmes[4].Titulo);
            Assert.Equal("Os Incríveis 2", primeiraFase.Filmes[5].Titulo);
            Assert.Equal("Thor: Ragnarok", primeiraFase.Filmes[6].Titulo);
            Assert.Equal("Vingadores: Guerra Infinita", primeiraFase.Filmes[7].Titulo);
        }

        [Fact]
        public void Realizar_Partidas_Da_Primeira_Fase()
        {
            // Arrange
            var primeiraFase = new PrimeiraFase(_filmes);

            // Act
            var vencedores = primeiraFase.RealizarPartidas();

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", vencedores[0].Titulo);
            Assert.Equal("Thor: Ragnarok", vencedores[1].Titulo);
            Assert.Equal("Os Incríveis 2", vencedores[2].Titulo);
            Assert.Equal("Jurassic World: Reino Ameaçado", vencedores[3].Titulo);
        }

        [Fact]
        public void Realizar_Partidas_Com_Quantidade_Incorreta()
        {
            // Arrange
            var filmes = new Faker<Filme>()
                .RuleFor(p => p.Nota, p => p.Random.Int(0, 10))
                .RuleFor(p => p.Titulo, p => p.Music.Random.String())
                .Generate(13);

            var primeiraFase = new PrimeiraFase(filmes);

            // Act
            var vencedores = primeiraFase.RealizarPartidas();

            // Assert
            Assert.Empty(vencedores);
        }
    }
}
