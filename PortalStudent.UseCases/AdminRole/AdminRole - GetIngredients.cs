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
        public List<Ingredient> GetIngredients()
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Ingredients.ToList();
            }
        }
    }
}
