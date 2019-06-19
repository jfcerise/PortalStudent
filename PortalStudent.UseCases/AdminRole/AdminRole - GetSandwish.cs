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
        public Sandwich GetSandwish(int id)
        {
            using(var ctx = new PortalContext())
            {
                //return ctx.Sandwiches.Include( x=>x.Ingredients).Any(s => s.SandwichId == id));

                /*var query = from s in ctx.Sandwiches
                            where s.SandwichId == id
                            select s;

                return query.FirstOrDefault<Sandwich>();*/

                return ctx.Sandwiches.Include(i => i.Ingredients).FirstOrDefault(x => x.SandwichId == id);
            }
        }
    }
}
