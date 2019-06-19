namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Sandwich_SandwichId", "dbo.Sandwiches");
            DropIndex("dbo.Ingredients", new[] { "Sandwich_SandwichId" });
            CreateTable(
                "dbo.IngredientSandwiches",
                c => new
                    {
                        Ingredient_IngredientId = c.Int(nullable: false),
                        Sandwich_SandwichId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_IngredientId, t.Sandwich_SandwichId })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Sandwiches", t => t.Sandwich_SandwichId, cascadeDelete: true)
                .Index(t => t.Ingredient_IngredientId)
                .Index(t => t.Sandwich_SandwichId);
            
            DropColumn("dbo.Ingredients", "Sandwich_SandwichId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Sandwich_SandwichId", c => c.Int());
            DropForeignKey("dbo.IngredientSandwiches", "Sandwich_SandwichId", "dbo.Sandwiches");
            DropForeignKey("dbo.IngredientSandwiches", "Ingredient_IngredientId", "dbo.Ingredients");
            DropIndex("dbo.IngredientSandwiches", new[] { "Sandwich_SandwichId" });
            DropIndex("dbo.IngredientSandwiches", new[] { "Ingredient_IngredientId" });
            DropTable("dbo.IngredientSandwiches");
            CreateIndex("dbo.Ingredients", "Sandwich_SandwichId");
            AddForeignKey("dbo.Ingredients", "Sandwich_SandwichId", "dbo.Sandwiches", "SandwichId");
        }
    }
}
