using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CollegWebApp.DAL;

namespace CollegWedApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}