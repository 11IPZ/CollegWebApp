using CollegWeb.Domain.Models;
using CollegWeb.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CollegWeb.Domain.Helpers;

namespace CollegWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;

        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {


                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, HashPasswordHelper.HashPassword(model.Password), model.RememberMe, false);
                if (result.Succeeded)
                {
                    // провіляєм,чи належить URL додатку
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильний логін і (або) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()

        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserApp user = new UserApp
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FullName = model.Fullname
                };

                string hashPassword = HashPasswordHelper.HashPassword(model.Password.ToString());

                // добавляєм користувача 
                var result = await _userManager.CreateAsync(user, hashPassword);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // видаляєм аутентифікаційні кукі
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
