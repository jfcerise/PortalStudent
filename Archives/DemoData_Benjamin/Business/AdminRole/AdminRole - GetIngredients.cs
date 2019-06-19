using Common.Domain;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public partial class AdminRole
    {
        public List<Ingredient> GetIngredients()
        {
            using(var ctx = new SandwishContext())
            {
                return ctx.ingredients.ToList();
            }
        }
    }
}
