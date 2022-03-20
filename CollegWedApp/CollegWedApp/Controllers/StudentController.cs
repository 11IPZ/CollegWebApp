using Microsoft.AspNetCore.Mvc;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Response;
using CollegWebApp.DAL;
using CollegWebApp.Service.Interfaces;
using CollegWebApp.Domain.Response;

namespace CollegWebApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
            studentService.Create(new Student()
            {
                Name = "Oleh",
                Surname = "Markelov",
                MiddleName = "Volodumurovuch",
                DateBorn = DateTime.Now,
            });
        }

        public async Task<IActionResult> Index()
        {
            var studentResponse = await studentService.GetById(0);
            return View(studentResponse);
        }
    }
}
