using CopaFilmes.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Application.AppServices.Interfaces
{
    public interface IFilmesAppService
    {
        Task<List<FilmeViewModel>> ObterTodos();
    }
}
