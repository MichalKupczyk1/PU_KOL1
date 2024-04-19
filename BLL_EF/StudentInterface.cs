using BLL;
using BLL.DTO;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data;

namespace BLL_EF
{
    public class StudentInterface : IStudentInterface
    {
        private readonly UczelniaContext _context;
        public StudentInterface(UczelniaContext context)
        {
            this._context = context;
        }

        public void AktualizujStudenta(int studentId, StudentDTO dto)
        {
            if (dto != null)
            {
                var student = _context.Studenci?.SingleOrDefault(x => x.Id == studentId);
                if (student != null)
                {
                    student.Imie = dto.Imie;
                    student.Nazwisko = dto.Nazwisko;
                    if (!dto.GrupaId.HasValue)
                    {
                        student.Grupa = null;
                        student.GrupaId = null;
                    }
                    else
                    {
                        if (student.GrupaId == null || student.GrupaId != dto.GrupaId)
                        {
                            var grupa = _context.Grupy?.SingleOrDefault(x => x.Id == dto.GrupaId.Value);
                            if (grupa != null)
                            {
                                student.Grupa = grupa;
                                student.GrupaId = grupa.Id;
                            }
                        }
                    }
                    _context.Update(student);
                    _context.SaveChanges();
                }
            }
        }

        public int? DodajStudenta(StudentDTO dto)
        {
            if (dto != null)
            {
                var student = new Student()
                {
                    Imie = dto.Imie,
                    Nazwisko = dto.Nazwisko
                };
                if (dto.GrupaId.HasValue)
                {
                    student.GrupaId = dto.GrupaId.Value;
                    student.Grupa = _context.Grupy?.SingleOrDefault(x => x.Id == dto.GrupaId.Value);
                }
                _context.Add(student);
                _context.SaveChanges();
                return student.Id;
            }
            return -1;
        }

        public int? DodajStudentaProcedura(StudentDTO dto)
        {
            var imie = new SqlParameter("@imie", dto.Imie);
            var nazwisko = new SqlParameter("@nazwisko", dto.Nazwisko);
            var grupaId = dto.GrupaId.HasValue ? new SqlParameter("@idGrupy", dto.GrupaId.Value) : new SqlParameter("@idGrupy", DBNull.Value);
            var id = new SqlParameter("@nowyStudentId", SqlDbType.Int) { Direction = ParameterDirection.Output };

            _context.Database.ExecuteSqlRaw("EXEC DodajStudenta @imie, @nazwisko, @idGrupy, @nowyStudentId OUTPUT",
                                                imie, nazwisko, grupaId, id);

            return (int)id.Value;
        }

        public StudentDTO PobierzStudenta(int? studentId)
        {
            if (studentId.HasValue)
            {
                var student = _context.Studenci?.SingleOrDefault(x => x.Id == studentId.Value);
                if (student != null)
                    return new StudentDTO(student);
            }
            return new StudentDTO();
        }

        public List<StudentDTO> PobierzWszystkichStudentow()
        {
            var studenci = _context.Studenci?.Select(x => new StudentDTO(x)).ToList();
            return studenci != null ? studenci : new List<StudentDTO>();
        }

        public bool UsunStudentaPoId(int? studentId)
        {
            if (studentId.HasValue)
            {
                var student = _context.Studenci?.SingleOrDefault(x => x.Id == studentId.Value);
                if (student != null)
                {
                    _context.Remove(student);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
