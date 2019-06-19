using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public bool AddSandwishInMenu(Sandwich NewSandwish)
        {
            if (NewSandwish == null)
                throw new ArgumentNullException(nameof(NewSandwish));

            if (NewSandwish.SandwichId != 0)
                throw new Exception(nameof(NewSandwish));
            
            if (String.IsNullOrEmpty(NewSandwish.Name) || String.IsNullOrWhiteSpace(NewSandwish.Name))
                throw new Exception(nameof(NewSandwish));

            using (var ctx = new PortalContext())
            {
                if (ctx.Sandwiches.Any(x => x.Name == NewSandwish.Name))
                {
                    throw new Exception(nameof(NewSandwish));
                }
                ctx.Sandwiches.Add(NewSandwish);
                ctx.SaveChanges();
            }

            return true;
        }
    }
}
