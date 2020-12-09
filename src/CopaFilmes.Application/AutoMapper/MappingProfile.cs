using AutoMapper;
using CopaFilmes.Application.ViewModels;
using CopaFilmes.Domain.Entities;

namespace CopaFilmes.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmeViewModel, Filme>().ReverseMap();
            CreateMap<PartidaViewModel, Partida>().ReverseMap();
        }
    }
}
