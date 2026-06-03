using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                TempData["Success"] = "Department Added Successfylly!";
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
                TempData["Success"] = "Department Edit Successfully";
               _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var departments = _context.Departments.Include(s => s.Student).ToList();
            var department=_context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {

            var departments = _context.Departments.Include(s => s.Student).FirstOrDefault(s => s.Id == id);
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                return View(department);

            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department != null)
            {
                TempData["Success"] = "Department Delete Successfully";
                _context.Remove(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }


        [HttpGet]
        public IActionResult Tolist()
        {
            var department = _context.Departments.Include(s => s.Student).ToList();
            return View(department);
        }
    }
}
