namespace Work.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "CountUsers", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "CountUsers", c => c.Int(nullable: false));
        }
    }
}
