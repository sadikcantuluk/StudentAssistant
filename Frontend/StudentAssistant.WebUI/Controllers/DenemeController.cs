using Microsoft.AspNetCore.Mvc;

namespace StudentAssistant.WebUI.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
