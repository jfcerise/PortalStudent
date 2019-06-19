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
        public List<Sandwich> GetSandwishes()
        {
            using(var ctx = new PortalContext())
            {
                return ctx.Sandwiches.ToList();
            }
        }
    }
}
