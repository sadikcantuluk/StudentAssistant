using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAssistandWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyController : ControllerBase
    {
        private readonly IDailyService _dailyService;

        public DailyController(IDailyService dailyService)
        {
            _dailyService = dailyService;
        }

        [HttpGet]
        public IActionResult GetDaily()
        {
            var values = _dailyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetDailyById(int id)
        {
            var value = _dailyService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDaily(Daily daily)
        {
            _dailyService.TUpdate(daily);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDaily(Daily daily)
        {
            _dailyService.TInsert(daily);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDaily(int id)
        {
            var removeItem = _dailyService.TGetById(id);
            _dailyService.TDelete(removeItem);
            return Ok();
        }
    }
}
