using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        public List<Filme> RealizarPrimeiraFase(List<Filme> filmes)
        {
            var primeiraFase = new PrimeiraFase(filmes);
            return primeiraFase.RealizarPartidas();
        }

        public List<Filme> RealizarFaseEliminatoria(List<Filme> filmes)
        {
            var faseEliminatoria = new FaseEliminatoria(filmes);
            return faseEliminatoria.RealizarPartidas();
        }

        public Partida RealizarFinal(List<Filme> filmes)
        {
            var partidaFinal = new Partida(filmes.FirstOrDefault(), filmes.Last());
            partidaFinal.Disputar();

            return partidaFinal;
        }
    }
}
