using Microsoft.AspNetCore.Mvc;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Students> objCategoryList = _db.students;
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Students obj)
        {
            _db.students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
