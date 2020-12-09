using AutoMapper;
using CopaFilmes.Application.AppServices.Interfaces;
using CopaFilmes.Application.ViewModels;
using CopaFilmes.Domain.Interfaces.CacheServices;
using CopaFilmes.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Application.AppServices.Services
{
    public class FilmesAppService : BaseAppService, IFilmesAppService
    {
        private readonly IFilmeService _filmeService;
        private readonly ICacheService _cacheService;

        public FilmesAppService(IMapper mapper, IFilmeService filmeService, ICacheService cacheService) : base(mapper)
        {
            _filmeService = filmeService;
            _cacheService = cacheService;
        }

        public async Task<List<FilmeViewModel>> ObterTodos()
        {
            if (_cacheService.ObterPelaChave("filmes", out object filmesViewModel))
                return filmesViewModel as List<FilmeViewModel>;

            var filmes = _mapper.Map<List<FilmeViewModel>>(await _filmeService.ObterTodos());
            _cacheService.Adicionar("filmes", filmes);

            return filmes;
        }
    }
}
