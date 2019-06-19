using PortalStudent.Common.Domain;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.DataAccess
{
    [DbConfigurationType(typeof(DataContextConfiguration))]
    public class PortalContext : DbContext
    {
        public PortalContext() : base("Server=tcp:cator.database.windows.net,1433;Initial Catalog=PortalStudent_db;Persist Security Info=False;User ID=gyssels;Password=AzurePa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {

        }

        //public DbSet<Class> Classes { get; set; }
        //public DbSet<Sandwich> Sandwiches { get; set; }
        //public DbSet<Ingredient> Ingredients { get; set; }

        //public DbSet<Student> Students { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Sandwich>()
        //                .HasMany<Ingredient>(s => s.Ingredients)
        //                .WithMany(i => i.Sandwiches);
        //}
    }
}
