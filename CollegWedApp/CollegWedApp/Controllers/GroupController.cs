using Microsoft.AspNetCore.Mvc;
using CollegWebApp.Domain.Models;
using CollegWebApp.Service.Interfaces;
using CollegWebApp.Domain.Response;

namespace CollegWebApp.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;
        public GroupController(IGroupService _groupService)
        {
            groupService = _groupService;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            BaseResponse<IEnumerable<Group>> groupsB = (BaseResponse<IEnumerable<Group>>)await groupService.GetAll();
            var groups = groupsB.Data;
            return View(groups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
            groupService.Create(group);
            return View();
        }
    }
}
