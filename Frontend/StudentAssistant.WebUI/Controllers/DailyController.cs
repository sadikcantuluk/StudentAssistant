using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using StudentAssistant.WebUI.Dtos.Daily;
using StudentAssistant.WebUI.Dtos.Student;

namespace StudentAssistant.WebUI.Controllers
{
    public class DailyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DailyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Daily");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultDailyDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailDaily(int id)
        {
            var client_2 = new HttpClient();

            //var client = _httpClientFactory.CreateClient();
            var responseMessage_2 = await client_2.GetAsync("https://localhost:7182/api/Student");
            var jsonData_2 = await responseMessage_2.Content.ReadAsStringAsync();
            var value_2 = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData_2);
            var studentInfo = value_2.FirstOrDefault();

            ViewBag.name = studentInfo.Name + "" + studentInfo.Surname;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7182/api/Daily/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultDailyDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddDaily()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDaily(AddDailyDto addDailyDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addDailyDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7182/api/Daily", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(3000);
                return RedirectToAction("Index", "Daily");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDaily(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7182/api/Daily/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDailyDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDaily(UpdateDailyDto updateDailyDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDailyDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7182/api/Daily", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(3000);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDaily(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7182/api/Daily/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                await Task.Delay(3000);
                return RedirectToAction("Index", "Daily");
            }
            return View();
        }
    }
}
