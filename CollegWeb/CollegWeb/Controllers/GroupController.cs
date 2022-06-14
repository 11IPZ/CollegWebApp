using CollegWeb.DAL.Interfaces;
using CollegWeb.Domain.Models;
using CollegWeb.Domain.Response;
using CollegWeb.Domain.ViewModels.Group;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollegWeb.Controllers
{
    public class GroupController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IGroupRepository _group;

        public GroupController(IGroupRepository group, UserManager<UserApp> userManager)
        {
            _group = group;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(User);
            BaseResponse<ICollection<Group>> baseResponseGroups = await _group.GetGroupsByUserId(id);
            var groups = (List<Group>)baseResponseGroups.Data;

            return View(groups);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupViewModel model)
        {
            
        }

    }
}
