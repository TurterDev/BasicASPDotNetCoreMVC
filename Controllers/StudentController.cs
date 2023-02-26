using BasicDotNetCoreMVC.Data;
using BasicDotNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicDotNetCoreMVC.Controllers
{
    public class StudentController : Controller
    {
        //Deoendency Injection
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Student s1 = new Student();
            // s1.Id = 1;
            // s1.Name = "Ronaldo";
            // s1.Score = 10;

            // var s2 = new Student();
            // s2.Id = 2;
            // s2.Name = "Turter Dev";
            // s2.Score = 100;

            // Student s3 = new();
            // s3.Id = 3;
            // s3.Name = "Messie";
            // s3.Score = 50;

            // List<Student> allStudent = new List<Student>();
            // allStudent.Add(s1);
            // allStudent.Add(s2);
            // allStudent.Add(s3);

            IEnumerable<Student> allStudent = _db.Students;

            return View(allStudent);
        }
        //GET Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid) //ตรวจสอบความถูดต้องของ Object ที่ส่งมา
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0){
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if(obj == null){
                return NotFound();
            }
            return View(obj);
        }
        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid) //ตรวจสอบความถูดต้องของ Object ที่ส่งมา
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0){
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if(obj == null){
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}