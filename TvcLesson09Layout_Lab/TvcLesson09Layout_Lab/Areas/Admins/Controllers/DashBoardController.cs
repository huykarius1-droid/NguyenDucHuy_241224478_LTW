using Microsoft.AspNetCore.Mvc;

namespace TvcLesson09Layout_Lab.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
