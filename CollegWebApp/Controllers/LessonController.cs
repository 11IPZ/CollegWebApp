using CollegWebApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IGroupRepository _groupRepository;
        public LessonController(ILessonRepository lessonRepository, IGroupRepository groupRepository)
        {
            _lessonRepository = lessonRepository;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = new MultiSelectList(await _groupRepository.GetAll(), "Id", "Name");

            return View();
        }
    }
}
