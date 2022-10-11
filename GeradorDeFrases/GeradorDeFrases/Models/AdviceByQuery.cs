

namespace GeradorDeFrases.Models
{
    public class AdviceByQuery
    {
        public int TotalResults { get; set; }
        public string Query { get; set; }
        public List<Slip> Slips { get; set; }
    }
}
