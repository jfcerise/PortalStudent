using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public bool AddIngredientInStock(Ingredient ingredientToAdd)
        {
            if (ingredientToAdd == null)
                throw new ArgumentNullException(nameof(ingredientToAdd));

            if (ingredientToAdd.IngredientId != 0)
                throw new Exception(nameof(ingredientToAdd));
            
            if (String.IsNullOrEmpty(ingredientToAdd.Name) || String.IsNullOrWhiteSpace(ingredientToAdd.Name))
                throw new Exception(nameof(ingredientToAdd));

            using (var ctx = new PortalContext())
            {
                if (ctx.Ingredients.Any(x => x.Name == ingredientToAdd.Name))
                {
                    throw new Exception(nameof(ingredientToAdd));
                }
                ctx.Ingredients.Add(ingredientToAdd);
                ctx.SaveChanges();
            }

            return true;
        }
    }
}
