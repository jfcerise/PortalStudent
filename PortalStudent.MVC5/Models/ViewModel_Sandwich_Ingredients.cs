using PortalStudent.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudent.MVC5.Models
{
    public class ViewModel_Sandwich_Ingredients
    {
        public Sandwich Sandwich { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public ViewModel_Sandwich_Ingredients(Sandwich sandwich, IEnumerable<Ingredient> ingredients)
        {
            Sandwich = sandwich;
            Ingredients = ingredients;
        }
    }
}