using Microsoft.AspNetCore.Mvc;
using CollegWebApp.Domain.Models;
using CollegWebApp.Service.Interfaces;

namespace CollegWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IGroupService groupService;

        public StudentController(IStudentService _studentService,
                                IGroupService _groupService)
        {
            studentService = _studentService;
            groupService = _groupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Groups = groupService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await studentService.Create(student);
            return View();
        }
    }
}
