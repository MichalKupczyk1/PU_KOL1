using BLL.DTO;

namespace BLL
{
    public interface IStudentInterface
    {
        public int? DodajStudenta(StudentDTO dto);
        public List<StudentDTO> PobierzWszystkichStudentow();
        public StudentDTO PobierzStudenta(int? studentId);
        public bool UsunStudentaPoId(int? studentId);
        public void AktualizujStudenta(int studentId, StudentDTO dto);
    }
}
