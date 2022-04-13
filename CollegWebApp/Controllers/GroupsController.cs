using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegWebApp.Controllers
{
    public class GroupsController : Controller
    {
        public readonly IGroupRepository _groupRepository;
        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<IActionResult> Index() => View(await _groupRepository.GetAll());
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Group group = new Group() { Name = name };
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
                ChangeGroupViewModel model = new ChangeGroupViewModel()
                {
                    Id = group.Id,
                    Name = group.Name
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ChangeGroupViewModel model)
        {
            if (!(model is null))
            {
                Group check = await _groupRepository.GetById(model.Id);
                if (!(check is null))
                {
                    Group group = new Group()
                    {
                        Id = model.Id,
                        Name = model.Name,
                    };
                    bool result = await _groupRepository.Update(group);
                    if (!result)
                    {
                        return RedirectToAction("Edit", model.Id);
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
