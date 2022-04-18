using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels.Lesson;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IGroupRepository _groupRepository;
        UserManager<User> _userManager;
        public LessonController(ILessonRepository lessonRepository, IGroupRepository groupRepository, UserManager<User> userManager)
        {
            _lessonRepository = lessonRepository;
            _groupRepository = groupRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int LessonId)
        {
            Lesson lesson = await _lessonRepository.GetById(LessonId);
            return View(lesson);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = new MultiSelectList(await _groupRepository.GetAll(), "Id", "Name");

            return View();
        }
        
        public async Task<IActionResult> Create(LessonCreateViewModel model)
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            Lesson lessonModel = new Lesson()
            {
                Name = model.Name,
                Description = model.Description,
                HtmlContext = model.HtmlContext,
                DateTimeCreate = DateTime.Today,
                CreatorId = user.Id
            };
            await _lessonRepository.CreateAsync(lessonModel);

            return RedirectToAction("View");
        }
    }
}
