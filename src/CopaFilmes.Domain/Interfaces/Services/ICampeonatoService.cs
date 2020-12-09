using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface ICampeonatoService
    {
        List<Filme> RealizarPrimeiraFase(List<Filme> filmes);
        List<Filme> RealizarFaseEliminatoria(List<Filme> filmes);
        Partida RealizarFinal(List<Filme> filmes);
    }
}
