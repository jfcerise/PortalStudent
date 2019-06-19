using PortalStudent.Common.Domain;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.DataAccess
{
    public class PortalContext : DbContext
    {
        public PortalContext() : base("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=RepasDB;Integrated Security=true")
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }
    }
}
