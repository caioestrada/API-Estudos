using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Interfaces.ApiServices
{
    public interface IFilmeApiService
    {
        Task<List<Filme>> ObterTodos();
    }
}
