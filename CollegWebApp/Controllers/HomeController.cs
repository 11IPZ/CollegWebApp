using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollegWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly IGroupRepository _groupRepository;
        public HomeController(ILogger<HomeController> logger, IGroupRepository groupRepository)
        {
            _logger = logger;
            _groupRepository = groupRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //await _groupRepository.CreateAsync(new Domain.Models.Group { Name = "11IPZ" });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}