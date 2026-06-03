using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var students = _context.Students
        .Include(s => s.Department)
        .ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();

            return View();
        }

        [HttpPost]

        public IActionResult Create(Student studens)
        {
            //Console.WriteLine("Student DSepartMnetId" + studens.DepartmentId);
            /*if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }*/
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Student Added Successfully!";
                _context.Students.Add(studens);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _context.Departments.ToList();

            
            return View(studens);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _context.Departments.ToList();
            var student = _context.Students.Find(id);
            if (student != null)
            {
                return View(student);
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Student Edited Successfully!";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            _context.Students.Include(d => d.Department).FirstOrDefault(d=>d.Id == id);
            var student = _context.Students.Find(id);
            if (student != null)
            {
                return View(student);
            }
            return View("Index");
        }



    }
}
