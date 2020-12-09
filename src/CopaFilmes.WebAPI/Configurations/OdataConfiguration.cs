using CopaFilmes.Application.ViewModels;
using CopaFilmes.Domain.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace CopaFilmes.WebAPI.Configurations
{
    public static class OdataConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Filme>("Filmes");
            builder.EntitySet<FilmeViewModel>("Filmes");

            return builder.GetEdmModel();
        }
    }
}
