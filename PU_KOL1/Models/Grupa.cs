using System.ComponentModel.DataAnnotations;

namespace PU_KOL1.Models
{
    public class Grupa
    {
        [Key]
        public int Id { get; set; }
        public string? Nazwa { get; set; }
    }
}
