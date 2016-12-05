namespace Work.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "DateStart", c => c.DateTime());
            AlterColumn("dbo.Events", "DateFinish", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "DateFinish", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "DateStart", c => c.DateTime(nullable: false));
        }
    }
}
