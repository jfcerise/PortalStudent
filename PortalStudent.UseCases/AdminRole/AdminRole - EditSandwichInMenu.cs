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
        public bool EditSandwichInMenu(Sandwich sandwichToEdit)
        {
            if (sandwichToEdit == null)
                throw new ArgumentNullException(nameof(sandwichToEdit));

            if (sandwichToEdit.SandwichId == 0)
                throw new Exception(nameof(sandwichToEdit));

            if (String.IsNullOrEmpty(sandwichToEdit.Name) || String.IsNullOrWhiteSpace(sandwichToEdit.Name))
                throw new Exception(nameof(sandwichToEdit));

            using (var ctx = new PortalContext())
            {
                ctx.Entry(sandwichToEdit).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return true;
        }
    }
}
