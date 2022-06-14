using Microsoft.AspNetCore.Mvc;

namespace CollegWeb.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
