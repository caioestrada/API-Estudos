using CopaFilmes.Domain.Entities;
using FluentValidation;

namespace CopaFilmes.Domain.Validators.FaseEliminatoriaValidator
{
    public class FaseEliminatoriaQuantidadeValidator : AbstractValidator<FaseEliminatoria>
    {
        public FaseEliminatoriaQuantidadeValidator()
        {
            RuleFor(fase => fase.Filmes).Must(filme => filme.Count % 2 == 0);
            RuleFor(fase => fase.Filmes).Must(filme => filme.Count == 4);
        }
    }
}
