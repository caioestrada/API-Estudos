using CopaFilmes.Application.AppServices.Interfaces;
using CopaFilmes.Application.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CopaFilmes.WebAPI.Controllers.v1
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmesAppService _filmeAppService;
        private readonly ICampeonatoAppService _campeonatoAppService;

        public FilmesController(IFilmesAppService filmeAppService, ICampeonatoAppService campeonatoAppService)
        {
            _filmeAppService = filmeAppService;
            _campeonatoAppService = campeonatoAppService;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<FilmeViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<FilmeViewModel>>> ObterTodos()
        {
            try
            {
                var filmes = await _filmeAppService.ObterTodos();
                if (filmes.Count() == 0)
                    return NotFound();

                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Competidores")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(PartidaViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public ActionResult<PartidaViewModel> RelizarCampeonato(List<FilmeViewModel> competidores)
        {
            try
            {
                var resultadoFinal = _campeonatoAppService.RealizarTorneio(competidores);
                if (string.IsNullOrEmpty(resultadoFinal?.Vencedor?.Titulo))
                    return BadRequest();

                return Ok(resultadoFinal);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
