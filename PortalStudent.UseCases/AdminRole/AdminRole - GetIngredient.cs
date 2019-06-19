using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public Ingredient GetIngredient(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            using(var ctx = new PortalContext())
            {
              return ctx.Ingredients.FirstOrDefault(x => x.IngredientId == id);
            }
        }
    }
}
