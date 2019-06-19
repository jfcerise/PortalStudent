using DataAccess;
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
        public List<Sandwich> GetSandwishes()
        {
            using(var ctx = new PortalContext())
            {
                return ctx.Sandwiches.ToList();
            }
        }
    }
}
