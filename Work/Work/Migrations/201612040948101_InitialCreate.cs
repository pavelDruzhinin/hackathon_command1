namespace Work.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateFinish = c.DateTime(nullable: false),
                        Location = c.String(),
                        CountUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventsUsers",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Telephone = c.String(),
                        Email = c.String(),
                        AboutMe = c.String(),
                        IsSportsman = c.Boolean(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventsUsers", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventsUsers", "UserId", "dbo.Users");
            DropIndex("dbo.EventsUsers", new[] { "UserId" });
            DropIndex("dbo.EventsUsers", new[] { "EventId" });
            DropTable("dbo.Users");
            DropTable("dbo.EventsUsers");
            DropTable("dbo.Events");
        }
    }
}
