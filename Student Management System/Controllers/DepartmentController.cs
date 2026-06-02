using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Data;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                return View(department);
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department != null)
            {
               _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]

        public IActionResult Details(int? id)
        {
            var department=_context.Departments.Find(id);
            if (department != null)
            {
                return View(department);
            }
            return View("Index");
        }
    }
}
