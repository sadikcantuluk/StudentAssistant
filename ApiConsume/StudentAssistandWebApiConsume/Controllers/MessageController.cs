using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentAssistant.WebUI.Dtos.Message;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace StudentAssistandWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Message()
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
                Content = new StringContent("{\r\n    \"model\": \"gpt-3.5-turbo\",\r\n    \"messages\": [\r\n        {\r\n            \"role\": \"user\",\r\n            \"content\": \"Hello, how are you?\"\r\n        }\r\n    ]\r\n}")
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
                return Ok(values.choices.ToList());
            }
        }
    }
}
