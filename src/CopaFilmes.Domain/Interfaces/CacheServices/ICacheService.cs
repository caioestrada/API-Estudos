using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.CacheServices
{
    public interface ICacheService
    {
        List<string> ObterTodos();
        bool ObterPelaChave(string chave, out object valor);
        bool Adicionar(string chave, object valor);
        void Remover(string chave);
    }
}
