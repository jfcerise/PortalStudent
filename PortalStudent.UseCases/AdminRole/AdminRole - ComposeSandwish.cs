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
        public bool ComposeSandwish(Sandwich sandwishToUse, ICollection<Ingredient> ingredientsToAdd)
        {
            foreach (var ing in ingredientsToAdd)
            {
                sandwishToUse.Ingredients.Add(ing);
            }

            using (var ctx = new PortalContext())
            {
                    if (!ctx.Sandwiches.Any(x => x.Name == sandwishToUse.Name))
                    {
                        throw new Exception(nameof(sandwishToUse));
                    }
                    ctx.Sandwiches.Attach(sandwishToUse);

                    ctx.SaveChanges();
                
            }

            return true;
        }

        public bool removeIngredientInComposition(int SId, int IId)
        {

            return true;
        }
    }
}
