using PortalStudent.Common.Domain;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalStudent.MVC5.Controllers
{
    public class SandwichController : Controller
    {
        // GET: Sandwich
        public ActionResult Index()
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwishes());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sandwich sandwich)
        {
            var adminRole = new AdminRole();

            adminRole.AddSandwishInMenu(sandwich);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwish(id));
        }


        [HttpPost]
        public ActionResult Edit(Sandwich sandwich)
        {
            var adminRole = new AdminRole();

            //adminRole.ed(sandwich);

            return RedirectToAction("Index");
        }

        /*
        [HttpGet]
        public ActionResult addInSandwich(Sandwich sandwich)
        {
            var adminRole = new AdminRole();
            return View(adminRole.GetIngredients());
        }

        [HttpPost]
        public ActionResult addInSandwich(Sandwich sandwich, Ingredient ingredient)
        {
            var adminRole = new AdminRole();

            adminRole.ComposeSandwish(sandwich, ingredient);
            return View("Composition",sandwich.SandwichId);
        }*/




        //[HttpGet]
        //public ActionResult Details()
        //{
        //    return View();
        //}

        //TODO Not in Benjamin
        [HttpPost]
        public ActionResult Details(int sandwichId)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwish(sandwichId));
        }


        #region By Benjamin
        [HttpGet]
        public ActionResult Composition(int id)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwish(id));
        }

        [HttpPost]
        public ActionResult Composition(Sandwich sandwich, ICollection<Ingredient> ingredients)
        {
            var adminRole = new AdminRole();

            adminRole.ComposeSandwish(sandwich, ingredients);

            return View("Index");
        }

        [HttpGet]
        public ActionResult DeleteIngredient(int SandwichId, int IngredientId)
        {
            var adminRole = new AdminRole();
            adminRole.removeIngredientInComposition(SandwichId, IngredientId);
            return View("Composition", SandwichId);
        }
        #endregion
    }
}