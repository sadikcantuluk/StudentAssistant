using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentAssistant.WebUI.Dtos.Daily;
using StudentAssistant.WebUI.Dtos.Notes;
using StudentAssistant.WebUI.Dtos.Student;
using System.Text;

namespace StudentAssistant.WebUI.Controllers
{
    public class NotesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Notes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultNotesDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailNotes(int id)
        {
            var client_2 = new HttpClient();

            //var client = _httpClientFactory.CreateClient();
            var responseMessage_2 = await client_2.GetAsync("https://localhost:7182/api/Student");
            var jsonData_2 = await responseMessage_2.Content.ReadAsStringAsync();
            var value_2 = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData_2);
            var studentInfo = value_2.FirstOrDefault();

            ViewBag.name = studentInfo.Name + "" + studentInfo.Surname;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7182/api/Notes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultNotesDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddNotes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNotes(AddNotesDto addNotesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addNotesDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7182/api/Notes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Notes");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotes(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7182/api/Notes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotesDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotes(UpdateNotesDto updateNotesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotesDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7182/api/Notes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotes(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7182/api/Notes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Notes");
            }
            return View();
        }
    }
}
