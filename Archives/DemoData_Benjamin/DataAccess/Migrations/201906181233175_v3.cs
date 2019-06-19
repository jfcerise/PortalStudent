namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IngredientSandwiches", newName: "SandwichIngredients");
            DropPrimaryKey("dbo.SandwichIngredients");
            AddPrimaryKey("dbo.SandwichIngredients", new[] { "Sandwich_SandwichId", "Ingredient_IngredientId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SandwichIngredients");
            AddPrimaryKey("dbo.SandwichIngredients", new[] { "Ingredient_IngredientId", "Sandwich_SandwichId" });
            RenameTable(name: "dbo.SandwichIngredients", newName: "IngredientSandwiches");
        }
    }
}
