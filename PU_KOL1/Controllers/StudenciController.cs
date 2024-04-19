using BLL;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PU_KOL1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudenciController : ControllerBase
    {
        private readonly IStudentInterface _studentInterface;
        private readonly IHistoriaInterface _historiaInterface;

        public StudenciController(IStudentInterface studentInterface, IHistoriaInterface historiaInterface)
        {
            _studentInterface = studentInterface;
            _historiaInterface = historiaInterface;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentInterface.PobierzStudenta(id);
            if (student != null)
                return Ok(student);
            return NotFound();
        }

        [HttpGet("GetStudenci")]
        public IActionResult GetStudenci()
        {
            var studenci = _studentInterface.PobierzWszystkichStudentow();
            if (studenci != null)
                return Ok(studenci);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO student)
        {
            if (student != null)
            {
                var id = _studentInterface.DodajStudenta(student);
                return id > 0 ? Ok(id) : NotFound();
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateStudent(int id, StudentDTO student)
        {
            if (student != null)
            {
                _studentInterface.AktualizujStudenta(id, student);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int? id)
        {
            if (id.HasValue)
            {
                var res = _studentInterface.UsunStudentaPoId(id);
                return res ? Ok(res) : NotFound();
            }
            return NotFound();
        }

        [HttpGet("GetHistoria")]
        public IActionResult GetHistoria([FromQuery] int strona, [FromQuery] int iloscNaStrone)
        {
            var res = _historiaInterface.PobierzHistorieZeStronnicowaniem(strona, iloscNaStrone);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
