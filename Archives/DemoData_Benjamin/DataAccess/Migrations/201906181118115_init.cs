namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Local = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Sandwiches",
                c => new
                    {
                        SandwichId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Class_ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.SandwichId)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId)
                .Index(t => t.Class_ClassId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Sandwich_SandwichId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Sandwiches", t => t.Sandwich_SandwichId)
                .Index(t => t.Sandwich_SandwichId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sandwiches", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Ingredients", "Sandwich_SandwichId", "dbo.Sandwiches");
            DropIndex("dbo.Ingredients", new[] { "Sandwich_SandwichId" });
            DropIndex("dbo.Sandwiches", new[] { "Class_ClassId" });
            DropTable("dbo.Ingredients");
            DropTable("dbo.Sandwiches");
            DropTable("dbo.Classes");
        }
    }
}
