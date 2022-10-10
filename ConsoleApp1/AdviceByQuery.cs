using ConsoleApp1;

namespace ConsumoDeApi
{
    internal class AdviceByQuery
    {
        public int TotalResults { get; set; }
        public string Query { get; set; }
        public List<Slip> Slips { get; set; }
    }
}
