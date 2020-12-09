using CopaFilmes.Domain.Entities;
using FluentValidation;

namespace CopaFilmes.Domain.Validators.PrimeiraFaseValidator
{
    public class PrimeiraFaseQuantidadeValidator : AbstractValidator<PrimeiraFase>
    {
        public PrimeiraFaseQuantidadeValidator()
        {
            RuleFor(fase => fase.Filmes).Must(filme => filme.Count % 2 == 0);
            RuleFor(fase => fase.Filmes).Must(filme => filme.Count == 8);
        }
    }
}
