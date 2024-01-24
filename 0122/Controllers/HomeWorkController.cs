using Microsoft.AspNetCore.Mvc;

namespace _0122.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
