using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Historia
    {
        [Key]
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public int? IdGrupy { get; set; }
        public TypAkcji TypaAkcji { get; set; }
        public DateTime Data { get; set; }
    }

    public enum TypAkcji
    {
        Edycja = 0,
        Usuwanie = 1
    }
}
