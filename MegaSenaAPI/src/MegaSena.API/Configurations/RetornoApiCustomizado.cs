using Newtonsoft.Json;

namespace MegaSena.API.Configurations
{
    public class RetornoApiCustomizado<T>
    {
        public bool Sucesso { get; set; }
        public T Dados { get; set; }
        [JsonProperty("Menssagem")]
        public string Menssagem { get; set; }
        public int Status { get; set; }
    }
}
