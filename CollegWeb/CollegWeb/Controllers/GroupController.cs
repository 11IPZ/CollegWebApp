using Microsoft.AspNetCore.Mvc;

namespace CollegWeb.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
