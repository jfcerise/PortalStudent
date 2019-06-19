using Common.Domain;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public partial class AdminRole
    {
        public bool EditIngredientInStock(Ingredient ingredientToEdit)
        {
            if (ingredientToEdit == null)
                throw new ArgumentNullException(nameof(ingredientToEdit));

            if (ingredientToEdit.IngredientId == 0)
                throw new Exception(nameof(ingredientToEdit));

            if (String.IsNullOrEmpty(ingredientToEdit.Name) || String.IsNullOrWhiteSpace(ingredientToEdit.Name))
                throw new Exception(nameof(ingredientToEdit));

            using (var ctx = new SandwishContext())
            {
                ctx.Entry(ingredientToEdit).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return true;
        }
    }
}
