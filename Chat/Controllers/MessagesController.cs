using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
