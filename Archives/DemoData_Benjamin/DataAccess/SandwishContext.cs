using Common.Domain;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SandwishContext : DbContext
    {
        public SandwishContext() : base("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=RepasDB;Integrated Security=true")
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }

        public DbSet<Ingredient> ingredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Sandwich>()
                        .HasMany<Ingredient>(s => s.Ingredients)
                        .WithMany(i => i.Sandwiches); 
                 

        }

    }
}
