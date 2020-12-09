using CopaFilmes.Domain.Entities;
using Xunit;

namespace CopaFilmes.Domain.Test.Entities
{
    public class PartidaTest
    {
        [Fact]
        public void Resolver_Partida()
        {
            // Arrange
            var primeiroCompetidor = new Filme { Titulo = "Vencedor", Nota = 10 };
            var segundoCompetidor = new Filme { Titulo = "Perdedor", Nota = 5 };

            // Act
            var vencedor = new Partida(primeiroCompetidor, segundoCompetidor).Disputar();

            // Assert
            Assert.Equal(primeiroCompetidor.Nota, vencedor.Nota);
            Assert.Equal(primeiroCompetidor.Titulo, vencedor.Titulo);
        }

        [Fact]
        public void Resolver_Partida_Com_Empate()
        {
            // Arrange
            var primeiroCompetidor = new Filme { Titulo = "EmpateB", Nota = 5 };
            var segundoCompetidor = new Filme { Titulo = "EmpateA", Nota = 5 };

            // Act
            var vencedor = new Partida(primeiroCompetidor, segundoCompetidor).Disputar();

            // Assert
            Assert.Equal(segundoCompetidor.Nota, vencedor.Nota);
            Assert.Equal(segundoCompetidor.Titulo, vencedor.Titulo);
        }
    }
}
