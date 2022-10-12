

using Newtonsoft.Json;

namespace GeradorDeFrases.Models
{
    public class AdviceByQuery
    {
        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
        public string Query { get; set; }
        public List<Slip> Slips { get; set; }
    }
}
