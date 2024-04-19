using Models;

namespace BLL.DTO
{
    public class HistoriaDTO
    {
        public int Id { get; init; }
        public string Imie { get; init; }
        public string Nazwisko { get; init; }
        public int GrupaId { get; init; }
        public TypAkcji TypAkcji { get; init; }
        public DateTime Data { get; init; }
    }
}
