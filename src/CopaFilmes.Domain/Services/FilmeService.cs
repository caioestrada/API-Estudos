using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces.ApiServices;
using CopaFilmes.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeApiService _filmeApiService;

        public FilmeService(IFilmeApiService filmeApiService)
        {
            _filmeApiService = filmeApiService;
        }

        public async Task<List<Filme>> ObterTodos()
        {
            return await _filmeApiService.ObterTodos();
        }
    }
}
