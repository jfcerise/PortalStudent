namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.SandwichId)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Class_ClassId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentFirstName = c.String(),
                        Class_ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId)
                .Index(t => t.Class_ClassId);
            
            CreateTable(
                "dbo.SandwichIngredients",
                c => new
                    {
                        Sandwich_SandwichId = c.Int(nullable: false),
                        Ingredient_IngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sandwich_SandwichId, t.Ingredient_IngredientId })
                .ForeignKey("dbo.Sandwiches", t => t.Sandwich_SandwichId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId, cascadeDelete: true)
                .Index(t => t.Sandwich_SandwichId)
                .Index(t => t.Ingredient_IngredientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Sandwiches", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Sandwiches", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.SandwichIngredients", "Ingredient_IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.SandwichIngredients", "Sandwich_SandwichId", "dbo.Sandwiches");
            DropIndex("dbo.SandwichIngredients", new[] { "Ingredient_IngredientId" });
            DropIndex("dbo.SandwichIngredients", new[] { "Sandwich_SandwichId" });
            DropIndex("dbo.Students", new[] { "Class_ClassId" });
            DropIndex("dbo.Sandwiches", new[] { "Student_StudentId" });
            DropIndex("dbo.Sandwiches", new[] { "Class_ClassId" });
            DropTable("dbo.SandwichIngredients");
            DropTable("dbo.Students");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Sandwiches");
            DropTable("dbo.Classes");
        }
    }
}
