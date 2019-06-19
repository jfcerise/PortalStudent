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
        public bool AddSandwishInMenu(Sandwich sandwishToUse)
        {
            if (sandwishToUse == null)
                throw new ArgumentNullException(nameof(sandwishToUse));

            if (sandwishToUse.SandwichId != 0)
                throw new Exception(nameof(sandwishToUse));
            
            if (String.IsNullOrEmpty(sandwishToUse.Name) || String.IsNullOrWhiteSpace(sandwishToUse.Name))
                throw new Exception(nameof(sandwishToUse));

            using (var ctx = new SandwishContext())
            {
                if (ctx.Sandwiches.Any(x => x.Name == sandwishToUse.Name))
                {
                    throw new Exception(nameof(sandwishToUse));
                }
                ctx.Sandwiches.Add(sandwishToUse);
                ctx.SaveChanges();
            }

            return true;
        }
    }
}
