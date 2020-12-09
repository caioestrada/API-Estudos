using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class Partida
    {
        public Filme PrimeiroCompetidor { get; private set; }
        public Filme SegundoCompetidor { get; private set; }
        public Filme Vencedor { get; private set; }
        public Filme Derrotado { get; private set; }

        public Partida(Filme primeiroCompetidor, Filme segundoCompetidor)
        {
            PrimeiroCompetidor = primeiroCompetidor;
            SegundoCompetidor = segundoCompetidor;
        }

        public Filme Disputar()
        {
            if (PrimeiroCompetidor.Nota == SegundoCompetidor.Nota)
                return ResolverEmpate(PrimeiroCompetidor, SegundoCompetidor);

            if (PrimeiroCompetidor.Nota > SegundoCompetidor.Nota)
            {
                Vencedor = PrimeiroCompetidor;
                Derrotado = SegundoCompetidor;

                return Vencedor;
            }

            Vencedor = SegundoCompetidor;
            Derrotado = PrimeiroCompetidor;

            return Vencedor;
        }

        private Filme ResolverEmpate(Filme primeiroCompetidor, Filme segundoCompetidor)
        {
            var listaDeFilmes = new List<Filme> { primeiroCompetidor, segundoCompetidor };
            var filmesOrdenados = listaDeFilmes.OrderBy(filme => filme.Titulo);

            Vencedor = filmesOrdenados.FirstOrDefault();
            Derrotado = filmesOrdenados.Last();

            return Vencedor;
        }
    }
}
