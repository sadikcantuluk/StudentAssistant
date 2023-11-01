using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAssistandWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var values = _studentService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var value = _studentService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.TUpdate(student);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.TInsert(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Student student)
        {
            _studentService.TDelete(student);
            return Ok();
        }
    }
}
