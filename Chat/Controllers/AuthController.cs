using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
