namespace mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "event_name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "event_pict", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "event_name", c => c.String());
            AlterColumn("dbo.Events", "event_pict", c => c.Byte());
        }
    }
}
