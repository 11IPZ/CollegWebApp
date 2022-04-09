using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;
        private readonly IGroupRepository _groupRepository;

        public UsersController(UserManager<User> userManager, IGroupRepository groupRepository)
        {
            _userManager = userManager;
            _groupRepository = groupRepository;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Create() {
            ViewBag.Groups = new SelectList(await _groupRepository.GetAll(), "Id", "Name");
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    UserSurname = model.UserSurname,
                    UserMiddleName = model.UserMiddleName,
                    UserGroupId = model.UserGroupId,
                    UserDataOfBirth = model.UserDataOfBirth,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);;
            ViewBag.Groups = new SelectList(await _groupRepository.GetAll(), "Id", "Name");

            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { 
                Id =  user.Id,
                Email = user.Email,
                Name = user.Name,
                UserSurname = user.UserSurname,
                UserMiddleName = user.UserMiddleName,
                UserGroupId = user.UserGroupId,
                UserDataOfBirth = user.UserDataOfBirth,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Name = model.Name;
                    user.UserSurname = model.UserSurname;
                    user.UserMiddleName = model.UserMiddleName;
                    user.UserDataOfBirth = model.UserDataOfBirth;
                    user.UserGroupId = model.UserGroupId;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
