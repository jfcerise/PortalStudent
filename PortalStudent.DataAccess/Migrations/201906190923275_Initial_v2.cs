namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Class_ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_ClassId" });
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Class_ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Class_ClassId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Class_ClassId);
            
            DropColumn("dbo.Students", "Class_ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Class_ClassId", c => c.Int());
            DropForeignKey("dbo.StudentClasses", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentClasses", new[] { "Class_ClassId" });
            DropIndex("dbo.StudentClasses", new[] { "Student_StudentId" });
            DropTable("dbo.StudentClasses");
            CreateIndex("dbo.Students", "Class_ClassId");
            AddForeignKey("dbo.Students", "Class_ClassId", "dbo.Classes", "ClassId");
        }
    }
}
