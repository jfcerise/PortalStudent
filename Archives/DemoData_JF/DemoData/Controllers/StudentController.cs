using Business;
using Common.Domain;
using System.Web.Mvc;

namespace DemoData.Controllers
{
    public class StudentController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            var adminRole = new AdminRole();
            return View(adminRole.GetStudents());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int StudentId)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetStudent(StudentId));
        }

        [HttpGet]
        public ActionResult Delete(int StudentId)
        {
            var adminRole = new AdminRole();
            return View(adminRole.GetStudent(StudentId));
        }

        [HttpPost]
        public ActionResult Create(Student monstudent)
        {
            var adminRole = new AdminRole();
            adminRole.AddStudent(monstudent);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Student monstudent)
        {
            var adminRole = new AdminRole();
            adminRole.UpdStudent(monstudent);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Student monstudent)
        {
            var adminRole = new AdminRole();
            adminRole.DelStudent(monstudent);
            return RedirectToAction("Index");
        }

    }
}