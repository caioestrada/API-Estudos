using CopaFilmes.Domain.Validators.FaseEliminatoriaValidator;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class FaseEliminatoria
    {
        public List<Filme> Filmes { get; set; }

        public FaseEliminatoria(List<Filme> filmes)
        {
            Filmes = filmes;
        }

        public List<Filme> RealizarPartidas()
        {
            var quantidadeCorretaDeFilmes = new FaseEliminatoriaQuantidadeValidator().Validate(this);
            if (!quantidadeCorretaDeFilmes.IsValid)
                return new List<Filme>();

            return DisputarPartidasEntrePrimeiroContraSegundo();
        }

        private List<Filme> DisputarPartidasEntrePrimeiroContraSegundo()
        {
            var listaDosVencedores = new List<Filme>();

            do
            {
                var primeiroCompetidor = Filmes.First();
                var segundoCompetidor = Filmes.Skip(1).Take(1).FirstOrDefault();

                listaDosVencedores.Add(new Partida(primeiroCompetidor, segundoCompetidor).Disputar());

                Filmes.Remove(primeiroCompetidor);
                Filmes.Remove(segundoCompetidor);

            } while (Filmes.Count > 0);

            return listaDosVencedores;
        }
    }
}
