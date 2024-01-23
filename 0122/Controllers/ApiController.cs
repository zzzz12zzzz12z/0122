using _0122.Models;
using Microsoft.AspNetCore.Mvc;

namespace _0122.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _dbContext;

        public ApiController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("<h2>Conctent,你好</h2>","text/plain",System.Text.Encoding.UTF8);
        }

        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult First()
        {
            return View();
        }
    }
}
