using PortalStudent.Common.Domain;
using PortalStudent.MVC5.Models;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [HttpPost]
        public ActionResult ListStudentSav(ClassWithStudentsVM maClasseStudent)
        {
            var adminRole = new AdminRole();

            adminRole.UpdateClassAttendence(maClasseStudent.Classe.ClassId, maClasseStudent.Students.Where(x => x.Subscribed == true).Select(x=> adminRole.GetStudent(x.StudentId)).ToList());

            //var existingStudent = adminRole.GetStudentsOfClass(maClasseStudent.Classe.ClassId).Select(x=>x.StudentId);
            //var deletedStudent = Queryable.Except<Student>(existingStudent.AsQueryable(), maClasseStudent.Students.Where(x=>x.Subscribed == true).Select(x => x.StudentId)).ToList();
            ////var addedStudent = maClasseStudent.Students.Where(a => a.Subscribed == true);

            //for (var i = 0; i < maClasseStudent.Students.Count(); i++)
            //{
            //    if  (maClasseStudent.Students[i].Subscribed == false)
            //    {
            //        var ViewValue1 = adminRole.RemoveStudent(maClasseStudent.Classe.ClassId, maClasseStudent.Students[i].StudentId);
            //    }
            //    else
            //    {
            //        var ViewValue2 = adminRole.AddStudent2(adminRole.GetClass(maClasseStudent.Classe.ClassId), adminRole.GetStudent(maClasseStudent.Students[i].StudentId));
            //    }
            //}

            return RedirectToAction("Details", new { ClassId = maClasseStudent.Classe.ClassId });
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
            var adminRole = new AdminRole();

            var ViewValue = adminRole.RemoveStudent2(adminRole.GetClass(ClassId), adminRole.GetStudent(StudentId));

            return RedirectToAction("Details", new { ClassId = ClassId });
        }

    }
}
