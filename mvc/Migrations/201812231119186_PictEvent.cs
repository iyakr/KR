namespace mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "event_pict", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "event_pict", c => c.Byte(nullable: false));
        }
    }
}
