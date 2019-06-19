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
        public List<Class> GetClasses()
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Classes.ToList();
            }
        }
        public Class GetClass(int ClassId)
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Classes.FirstOrDefault(x => x.ClassId == ClassId);
            }
        }
    }
}

