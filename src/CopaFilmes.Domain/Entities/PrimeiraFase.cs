using CopaFilmes.Domain.Validators.PrimeiraFaseValidator;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class PrimeiraFase
    {
        public List<Filme> Filmes { get; set; }

        public PrimeiraFase(List<Filme> filmes)
        {
            Filmes = filmes;
        }

        public List<Filme> RealizarPartidas()
        {
            var quantidadeCorretaDeFilmes = new PrimeiraFaseQuantidadeValidator().Validate(this);
            if (!quantidadeCorretaDeFilmes.IsValid)
                return new List<Filme>();

            OrdenarFilmesPorOrdemAlfabetica();

            return DisputarPartidasEntrePrimeiroContraUltimo();
        }

        public void OrdenarFilmesPorOrdemAlfabetica() => Filmes = Filmes.OrderBy(filme => filme.Titulo).ToList();

        private List<Filme> DisputarPartidasEntrePrimeiroContraUltimo()
        {
            var listaDosVencedores = new List<Filme>();

            do
            {
                var primeiroCompetidor = Filmes.First();
                var segundoCompetidor = Filmes.Last();

                listaDosVencedores.Add(new Partida(primeiroCompetidor, segundoCompetidor).Disputar());

                Filmes.Remove(primeiroCompetidor);
                Filmes.Remove(segundoCompetidor);

            } while (Filmes.Count > 0);

            return listaDosVencedores;
        }
    }
}
