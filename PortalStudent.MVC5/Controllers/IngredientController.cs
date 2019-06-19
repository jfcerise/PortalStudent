using PortalStudent.Common.Domain;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalStudent.MVC5.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetIngredients());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingredient ing)
        {
            var adminRole = new AdminRole();

            adminRole.AddIngredientInStock(ing);

            // return View("Index", adminRole.GetIngredients());

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetIngredient(id));
        }

        [HttpPost]
        public ActionResult Edit(Ingredient ing)
        {
            var adminRole = new AdminRole();

            adminRole.EditIngredientInStock(ing);

            // return View("Index", adminRole.GetIngredients());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var adminRole = new AdminRole();

            adminRole.DeleteIngredientInStock(id);

            // return View("Index", adminRole.GetIngredients());
            return RedirectToAction("Index");
        }

    }
}