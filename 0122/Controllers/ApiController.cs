using _0122.Models;
using _0122.Models.DTO;
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

        public IActionResult CheckAccount(string name)
        {
            var result = _dbContext.Members
                            .Where(m => m.Name.Contains(name)).Any();
            return Content(result.ToString());
        }

        [HttpPost]
        public IActionResult Register(UserDTO _user)
        {
            if(string.IsNullOrEmpty(_user.Name))
               
            {
               _user.Name = "Guest";
            };
            return Content($"Hello{_user.Name},{_user.Age}歲了,電子郵件是{_user.Email}");
        }
        [HttpPost]
        public IActionResult Spots([FromBody] SearchDTO _search)
        {
            var spots =_search.categoryId == 0 ? _dbContext.SpotImagesSpots: _dbContext.SpotImagesSpots.Where(s => s.CategoryId == _search.categoryId);

            //根據關鍵字搜尋
            if (!string.IsNullOrEmpty(_search.keyword))
            {
                spots.Where(s => s.SpotTitle.Contains(_search.keyword) || s.SpotDescription.Contains(_search.keyword));
            }
            //排序
            switch (_search.sortBy)
            {
                case "spotTitle":
                    spots = _search.sortType == "asc" ? spots.OrderBy(s => s.SpotTitle) : spots.OrderByDescending(s => s.SpotTitle);
                    break;

                case "categoryId":
                    spots = _search.sortType == "asc" ? spots.OrderBy(s => s.CategoryId) : spots.OrderByDescending(s => s.CategoryId);
                    break;

                default:
                    spots = _search.sortType == "asc" ? spots.OrderBy(s => s.SpotId) : spots.OrderByDescending(s => s.SpotId);
                    break;
            }
            //分頁
            int TotalCount = spots.Count();//搜尋出來的資料總共有幾筆
            int pageSize = _search.PageSize ?? 9;//每頁顯示幾筆
            int TotalPage = (int)Math.Ceiling((decimal)TotalCount / pageSize);//計算出總頁數
            int page = _search.Page ?? 1;//第幾頁

            //取出分頁資料
            spots = spots.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(spots);
        }
    }
}
