using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Student studens)
        {
            if(ModelState.IsValid)
            {
                _context.Students.Add(studens);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["StudentNotAdd"] = "Student Not Add";
            return View("Index");
        }

    }
}
