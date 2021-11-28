using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CollegApp.Models;

namespace CollegApp.Controllers
{
    public class HomeController : Controller
    {
        CollegeContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CollegeContext context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Student student= await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Student student= await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id!=null)
            {
                Student student= await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            db.Students.Update(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
