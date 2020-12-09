using AutoMapper;

namespace CopaFilmes.Application.AppServices.Services
{
    public class BaseAppService
    {
        protected readonly IMapper _mapper;

        public BaseAppService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
