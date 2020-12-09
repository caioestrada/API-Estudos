using CopaFilmes.Application.ViewModels;
using System.Collections.Generic;

namespace CopaFilmes.Application.AppServices.Interfaces
{
    public interface ICampeonatoAppService
    {
        PartidaViewModel RealizarTorneio(List<FilmeViewModel> filmeViewModel);
    }
}
