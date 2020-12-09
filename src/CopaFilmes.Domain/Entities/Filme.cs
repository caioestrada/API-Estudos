using System.Text.Json.Serialization;

namespace CopaFilmes.Domain.Entities
{
    public class Filme
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("ano")]
        public int Ano { get; set; }

        [JsonPropertyName("nota")]
        public double Nota { get; set; }
    }
}
