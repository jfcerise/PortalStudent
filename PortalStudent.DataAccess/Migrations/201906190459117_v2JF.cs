namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2JF : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Sandwiches", "Student_StudentId", c => c.Int());
            CreateIndex("dbo.Sandwiches", "Student_StudentId");
            AddForeignKey("dbo.Sandwiches", "Student_StudentId", "dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Sandwiches", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Class_ClassId" });
            DropIndex("dbo.Sandwiches", new[] { "Student_StudentId" });
            DropColumn("dbo.Sandwiches", "Student_StudentId");
            DropTable("dbo.Students");
        }
    }
}
