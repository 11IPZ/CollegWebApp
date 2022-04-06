using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IGroupRepository _groupRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IGroupRepository groupRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _groupRepository = groupRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.Groups = new SelectList(await _groupRepository.GetAll(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Group selectGroup = await _groupRepository.GetById(model.UserGroupId);

                User user = new User { 
                    Email = model.Email,
                    UserName = model.UserName,
                    UserSurname = model.UserSurname,
                    UserMiddleName = model.UserMiddleName,
                    UserGroup = selectGroup,
                    UserDataOfBirth = model.UserDataOfBirth, };

                // добавляєм користувача 
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // встановляємо кукі
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
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
    }
}
