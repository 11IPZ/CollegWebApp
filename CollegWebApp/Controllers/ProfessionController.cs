using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProfessionController : Controller
    {
        private readonly IProfessionRepository _professionRepository;

        public ProfessionController(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task<IActionResult> Index() => View(await _professionRepository.GetAll());
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Profession profession = new Profession() { Name = name };
                bool result = await _professionRepository.CreateAsync(profession);

                if(result)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Profession profession = await _professionRepository.GetById(id);
            if(!(profession is null))
            {
                ChangeProfessionViewModel model = new ChangeProfessionViewModel()
                {
                    Id = profession.Id,
                    Name = profession.Name
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ChangeProfessionViewModel model)
        {
            if(!(model is null))
            {
                Profession check = await _professionRepository.GetById(model.Id);
                if (!(check is null))
                {
                    Profession profession = new Profession()
                    {
                        Id= model.Id,
                        Name = model.Name,
                    };
                    bool result = await _professionRepository.Update(profession);
                    if(!result)
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
            await _professionRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
