using Business;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoData.Controllers
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

            return View("Index");
        }

        [HttpGet]
        public ActionResult Composition(int id)
        {
            var adminRole = new AdminRole();
         
            return View(adminRole.GetSandwish(id));
        }

        [HttpPost]
        public ActionResult Composition(Sandwich sandwich,ICollection<Ingredient> ingredients)
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
    }
}