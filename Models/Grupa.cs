using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Grupa
    {
        [Key]
        public int Id { get; set; }
        public string? Nazwa { get; set; }
    }
}
