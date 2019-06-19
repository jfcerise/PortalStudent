namespace DataAccess.Migrations
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Sandwiches", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Sandwiches", "Class_ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_ClassId" });
            DropIndex("dbo.Sandwiches", new[] { "Student_StudentId" });
            DropIndex("dbo.Sandwiches", new[] { "Class_ClassId" });
            DropTable("dbo.Students");
            DropTable("dbo.Sandwiches");
            DropTable("dbo.Classes");
        }
    }
}
