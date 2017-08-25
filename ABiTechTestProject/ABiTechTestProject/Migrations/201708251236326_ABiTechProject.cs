namespace ABiTechTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ABiTechProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SurName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Problems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Problems", "PersonId", "dbo.People");
            DropIndex("dbo.Problems", new[] { "PersonId" });
            DropIndex("dbo.Problems", new[] { "StatusId" });
            DropTable("dbo.Status");
            DropTable("dbo.Problems");
            DropTable("dbo.People");
        }
    }
}
