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
        public bool AddClassInMenu(Class ClassToUse)
        {
            if (ClassToUse == null)
                throw new ArgumentNullException(nameof(ClassToUse));

            if (ClassToUse.ClassId != 0)
                throw new Exception(nameof(ClassToUse));

            if (String.IsNullOrEmpty(ClassToUse.Local) || String.IsNullOrWhiteSpace(ClassToUse.Local))
                throw new Exception(nameof(ClassToUse));

            using (var ctx = new PortalContext())
            {
                if (ctx.Classes.Any(x => x.Local == ClassToUse.Local))
                {
                    throw new Exception(nameof(ClassToUse));
                }
                ctx.Classes.Add(ClassToUse);
                ctx.SaveChanges();
            }

            return true;
        }
        public bool UpdClass(Class ClassToUse)
        {
            if (ClassToUse == null)
                throw new ArgumentNullException(nameof(ClassToUse));

            if (String.IsNullOrEmpty(ClassToUse.Local) || String.IsNullOrWhiteSpace(ClassToUse.Local))
                throw new Exception(nameof(ClassToUse));

            using (var ctx = new PortalContext())
            {
                ctx.Entry(ClassToUse).State = EntityState.Modified;
                ctx.SaveChanges();
            }

            return true;
        }

        public bool DelClass(Class ClassToUse)
        {
            if (ClassToUse == null)
                throw new ArgumentNullException(nameof(ClassToUse));

            using (var ctx = new PortalContext())
            {
                ctx.Entry(ClassToUse).State = EntityState.Deleted;
                ctx.SaveChanges();
            }

            return true;
        }
    }
}
