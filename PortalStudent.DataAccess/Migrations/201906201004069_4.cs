namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentClasses", name: "Student_StudentId", newName: "StudentId");
            RenameColumn(table: "dbo.StudentClasses", name: "Class_ClassId", newName: "ClassId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "Sandwich_SandwichId", newName: "SandwichId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "Ingredient_IngredientId", newName: "IngredientId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_Sandwich_SandwichId", newName: "IX_SandwichId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_Ingredient_IngredientId", newName: "IX_IngredientId");
            RenameIndex(table: "dbo.StudentClasses", name: "IX_Class_ClassId", newName: "IX_ClassId");
            RenameIndex(table: "dbo.StudentClasses", name: "IX_Student_StudentId", newName: "IX_StudentId");
            DropPrimaryKey("dbo.StudentClasses");
            AddPrimaryKey("dbo.StudentClasses", new[] { "ClassId", "StudentId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StudentClasses");
            AddPrimaryKey("dbo.StudentClasses", new[] { "Student_StudentId", "Class_ClassId" });
            RenameIndex(table: "dbo.StudentClasses", name: "IX_StudentId", newName: "IX_Student_StudentId");
            RenameIndex(table: "dbo.StudentClasses", name: "IX_ClassId", newName: "IX_Class_ClassId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_IngredientId", newName: "IX_Ingredient_IngredientId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_SandwichId", newName: "IX_Sandwich_SandwichId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "IngredientId", newName: "Ingredient_IngredientId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "SandwichId", newName: "Sandwich_SandwichId");
            RenameColumn(table: "dbo.StudentClasses", name: "ClassId", newName: "Class_ClassId");
            RenameColumn(table: "dbo.StudentClasses", name: "StudentId", newName: "Student_StudentId");
        }
    }
}
