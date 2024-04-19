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

        public StudenciController(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface;
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
        public IActionResult GetStudenci(int id)
        {
            var studenci = _studentInterface.PobierzWszystkichStudentow();
            if (studenci != null)
                return Ok(studenci);
            return NotFound();
        }
    }
}
