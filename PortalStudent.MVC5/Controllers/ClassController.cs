using PortalStudent.Common.Domain;
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
    }
}
