using Models;

namespace BLL.DTO
{
    public class HistoriaDTO
    {
        public int Id { get; init; }
        public string? Imie { get; init; }
        public string? Nazwisko { get; init; }
        public int? GrupaId { get; init; }
        public TypAkcji TypAkcji { get; init; }
        public DateTime Data { get; init; }

        public HistoriaDTO() { }
        public HistoriaDTO(Historia historia)
        {
            Id = historia.Id;
            Imie = historia.Imie;
            Nazwisko = historia.Nazwisko;
            GrupaId = historia.GrupaId;
            TypAkcji = historia.TypAkcji;
            Data = historia.Data;
        }
    }
}
