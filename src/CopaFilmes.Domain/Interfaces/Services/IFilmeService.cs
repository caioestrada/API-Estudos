using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface IFilmeService
    {
        Task<List<Filme>> ObterTodos();
    }
}
