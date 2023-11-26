using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAssistandWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            var values = _notesService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotesById(int id)
        {
            var value = _notesService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotes(Notes notes)
        {
            _notesService.TUpdate(notes);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddNotes(Notes notes)
        {
            _notesService.TInsert(notes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotes(int id)
        {
            var notes = _notesService.TGetById(id);
            _notesService.TDelete(notes);
            return Ok();
        }
    }
}
