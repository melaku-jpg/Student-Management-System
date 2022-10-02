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
        //GET
        public IActionResult Index()
        {
            IEnumerable<Students> objCategoryList = _db.students;
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Students obj)
        {
            if (obj.StudentName == obj.StudentGrade.ToString())
            {
                ModelState.AddModelError("StudentName", "The Name can not be the same as the grade");

            }
            if (ModelState.IsValid)
            {
                _db.students.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var studentsFromDb = _db.students.Find(id);
            //var studentsFromDbFirst = _db.students.FirstOrDefault(u=>u.StudentId==id);
            if (studentsFromDb == null)
            {
                return NotFound();
            }
            return View(studentsFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Students obj)
        {
            if (obj.StudentName == obj.StudentGrade.ToString())
            {
                ModelState.AddModelError("StudentName", "The Name can not be the same as the grade");

            }
            if (ModelState.IsValid)
            {
                _db.students.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //POST
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentsFromDb = _db.students.Find(id);
            //var studentsFromDbFirst = _db.students.FirstOrDefault(u=>u.StudentId==id);
            if (studentsFromDb == null)
            {
                return NotFound();
            }
            return View(studentsFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
     
                _db.students.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Student Deleted Successfully"; 
            return RedirectToAction("Index");
            }
    

    }
}
