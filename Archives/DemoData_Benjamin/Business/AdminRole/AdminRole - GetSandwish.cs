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
        public Sandwich GetSandwish(int id)
        {
            using(var ctx = new SandwishContext())
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
