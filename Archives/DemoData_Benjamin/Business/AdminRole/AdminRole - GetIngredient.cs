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
        public Ingredient GetIngredient(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            using(var ctx = new SandwishContext())
            {
              return ctx.ingredients.FirstOrDefault(x => x.IngredientId == id);
            }
        }
    }
}
