using AutoMapper;
using CopaFilmes.Application.AppServices.Interfaces;
using CopaFilmes.Application.ViewModels;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CopaFilmes.Application.AppServices.Services
{
    public class CampeonatoAppService : BaseAppService, ICampeonatoAppService
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoAppService(IMapper mapper, ICampeonatoService campeonatoService) : base (mapper)
        {
            _campeonatoService = campeonatoService;
        }

        public PartidaViewModel RealizarTorneio(List<FilmeViewModel> filmeViewModel)
        {
            var filmes = _mapper.Map<List<Filme>>(filmeViewModel);

            var filmesDaPrimeiraFase = _campeonatoService.RealizarPrimeiraFase(filmes);
            if (filmesDaPrimeiraFase.Count == 0)
                return new PartidaViewModel();

            var filmesDaFaseEliminatoria = _campeonatoService.RealizarFaseEliminatoria(filmesDaPrimeiraFase);
            return _mapper.Map<PartidaViewModel>(_campeonatoService.RealizarFinal(filmesDaFaseEliminatoria));
        }
    }
}
