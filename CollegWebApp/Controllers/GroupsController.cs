using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using CollegWebApp.Domain.ViewModels.Groups;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class GroupsController : Controller
    {
        public readonly IGroupRepository _groupRepository;
        public readonly IProfessionRepository _professionRepository;
        UserManager<User> _userManager;
        public GroupsController(IGroupRepository groupRepository, IProfessionRepository professionRepository, UserManager<User> userManager)
        {
            _groupRepository = groupRepository;
            _professionRepository = professionRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var group = await _groupRepository.GetAll();
            return View(group);
        }
        public async Task<IActionResult> Students(int GroupId)
        {
            /*var users = _userManager.Users.Where(i => i.UserGroupId == GroupId).ToList();*/
            List<string> usersId = await _groupRepository.FindUsers(GroupId);
            List<User> users = new List<User>();

            if (usersId != null)
            {
                foreach (var item in usersId)
                {
                    users.Add(await _userManager.FindByIdAsync(item));
                }
            }
            return View(users);

        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Profession = new SelectList(await _professionRepository.GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                Profession profession = await _professionRepository.GetById(model.ProfessionId + 1);
                Group group = new Group() { Name = model.Name,  Profession = profession};

                bool result = await _groupRepository.CreateAsync(group);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Group group = await _groupRepository.GetById(id);
            if (!(group is null))
            {
                EditGroupViewModel model = new EditGroupViewModel()
                {
                    Id = group.Id,
                    Name = group.Name,
                };
                ViewBag.Profession = new SelectList(await _professionRepository.GetAll(), "Id", "Name");
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditGroupViewModel model)
        {
            if (!(model is null))
            {
                Group check = await _groupRepository.GetById(model.Id);
                if (!(check is null))
                {
                    Profession profession = await _professionRepository.GetById(model.ProfessionId + 1);

                    if (profession != null)
                    {
                        Group group = new Group()
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Profession = profession,
                        };
                        bool result = await _groupRepository.Update(group);
                        if (!result)
                        {
                            return RedirectToAction("Edit", model.Id);
                        }
                    }
                }

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _groupRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
