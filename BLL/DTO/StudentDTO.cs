using Models;

namespace BLL.DTO
{
    public class StudentDTO
    {
        public int Id { get; init; }
        public string? Imie { get; init; }
        public string? Nazwisko { get; init; }
        public int? GrupaId { get; init; }

        public StudentDTO() { }
        public StudentDTO(Student student)
        {
            Id = student.Id;
            Nazwisko = student.Nazwisko;
            Imie = student.Imie;
            GrupaId = student.GrupaId;
        }
    }
}
