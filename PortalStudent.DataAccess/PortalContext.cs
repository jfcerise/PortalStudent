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
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Sandwich>()
                        .HasMany<Ingredient>(s => s.Ingredients)
                        .WithMany(i => i.Sandwiches)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("SandwichId");
                            cs.MapRightKey("IngredientId");
                            cs.ToTable("SandwichIngredients");
                        }); ;

            modelBuilder.Entity<Class>()
            .HasMany<Student>(c => c.Students)
            .WithMany(s => s.Classes)
            .Map(cs =>
            {
                cs.MapLeftKey("ClassId");
                cs.MapRightKey("StudentId");
                cs.ToTable("StudentClasses");
            }); ;
        }
    }
}
