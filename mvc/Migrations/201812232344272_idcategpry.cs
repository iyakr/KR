namespace mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idcategpry : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
        }
    }
}
