﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentAssistant.WebUI.Dtos.Message;
using StudentAssistant.WebUI.Dtos.Student;
using System.Net.Http;
using System.Net.Http.Headers;
namespace StudentAssistant.WebUI.Controllers
{
    public class YazılımGerçeklemeVeTestController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> YazılımGerçeklemeVeTestMessage()
        {
            var client = new HttpClient();

            //var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Student");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData);
            var studentInfo = value.FirstOrDefault();

            var defaultText = $"Merhaba ben {studentInfo.Name} {studentInfo.Surname}.{studentInfo.Department} {studentInfo.Class}. sınıf öğrencisiyim.Yazılım Gerçekleme ve Test dersim ile ilgili sana soru soracağım.";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chatgpt-best-price.p.rapidapi.com/v1/chat/completions"),
                Headers =
    {
        { "X-RapidAPI-Key", "9284c70ef1msh3396da3a7d254c0p104f22jsna3bd8d1c3078" },
        { "X-RapidAPI-Host", "chatgpt-best-price.p.rapidapi.com" },
    },
                Content = new StringContent($"{{ \"model\": \"gpt-3.5-turbo\", \"messages\": [{{ \"role\": \"user\", \"content\": \"{defaultText}\" }} ] }}")

                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MessageViewModel>(body);
                return View(values);
            }
        }

        [HttpPost]
        public async Task<IActionResult> YazılımGerçeklemeVeTestMessage(MessageViewModel requestMessageViewModel)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chatgpt-best-price.p.rapidapi.com/v1/chat/completions"),
                Headers =
    {
        { "X-RapidAPI-Key", "9284c70ef1msh3396da3a7d254c0p104f22jsna3bd8d1c3078" },
        { "X-RapidAPI-Host", "chatgpt-best-price.p.rapidapi.com" },
    },
                Content = new StringContent($"{{ \"model\": \"gpt-3.5-turbo\", \"messages\": [{{ \"role\": \"user\", \"content\": \"{requestMessageViewModel.Question}\" }} ] }}")

                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MessageViewModel>(body);
                return View(values);
            }
        }
    }
}
