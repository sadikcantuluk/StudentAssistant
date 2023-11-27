using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentAssistant.WebUI.Dtos.Student;
using System.Text;

namespace StudentAssistant.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Student");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7182/api/Student/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStudentDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto updateStudentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStudentDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7182/api/Student",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(3000);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
