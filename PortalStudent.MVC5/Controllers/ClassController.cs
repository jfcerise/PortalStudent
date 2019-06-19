using PortalStudent.Common.Domain;
using PortalStudent.MVC5.Models;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalStudent.MVC5.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            var adminRole = new AdminRole();
            return View(adminRole.GetClasses());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ClassId)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetClass(ClassId));
        }

        [HttpGet]
        public ActionResult Delete(int ClassId)
        {
            var adminRole = new AdminRole();
            return View(adminRole.GetClass(ClassId));
        }

        [HttpPost]
        public ActionResult Create(Class maclasse)
        {
            var adminRole = new AdminRole();
            adminRole.AddClassInMenu(maclasse);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Class maclasse)
        {
            var adminRole = new AdminRole();
            adminRole.UpdClass(maclasse);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Class maclasse)
        {
            var adminRole = new AdminRole();
            adminRole.DelClass(maclasse);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int ClassId)
        {
            var adminRole = new AdminRole();
            var students = adminRole.GetStudentsOfClass(ClassId).Select(x => new StudentSubscriptionVM { StudentId = x.StudentId, Name = $"{x.StudentName}, {x.StudentFirstName}", Subscribed = true }).ToList();
            var ViewValue = new ClassWithStudentsVM { Classe = adminRole.GetClass(ClassId), Students = students };

            return View(ViewValue);
        }

        [HttpGet]
        public ActionResult ListStudent(int ClassId)
        {
            var adminRole = new AdminRole();

            // var students = adminRole.GetStudents().Except(adminRole.GetStudentsOfClass(ClassId)).ToList();
            var students = adminRole.GetStudents().Select(x => new StudentSubscriptionVM { StudentId = x.StudentId, Name = $"{x.StudentName}, {x.StudentFirstName}", Subscribed = false }).ToList();
            var studentsSubscribed = adminRole.GetStudentsOfClass(ClassId).ToList();

            students.ForEach(x => x.Subscribed = studentsSubscribed.Any(y => y.StudentId == x.StudentId));
            var ViewValue = new ClassWithStudentsVM { Classe = adminRole.GetClass(ClassId), Students = students };


            return View(ViewValue);//ajouter page de selection
        }

        [HttpGet]
        public ActionResult AddStudent(int ClassId, int StudentId)
        {
            var adminRole = new AdminRole();

            var ViewValue = adminRole.AddStudent2(adminRole.GetClass(ClassId),adminRole.GetStudent(StudentId));

            return RedirectToAction("Details", new { ClassId = ClassId });
        }
        [HttpGet]
        public ActionResult RemoveStudent(int ClassId, int StudentId)
        {
            //remove student de la classes

            return RedirectToAction("Details", new { ClassId = ClassId });
        }

    }
}
