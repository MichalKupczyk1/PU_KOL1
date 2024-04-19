using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PU_KOL1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        [ForeignKey(nameof(GrupaId))]
        public int? GrupaId { get; set; }
        public Grupa? Grupa { get; set; }
    }
}
