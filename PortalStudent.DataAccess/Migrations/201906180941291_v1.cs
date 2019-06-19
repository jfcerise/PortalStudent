namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
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

        }

        public override void Down()
        {
            DropForeignKey("dbo.Sandwiches", "Class_ClassId", "dbo.Classes");
            DropIndex("dbo.Sandwiches", new[] { "Class_ClassId" });
            DropTable("dbo.Sandwiches");
            DropTable("dbo.Classes");
        }
    }
}
