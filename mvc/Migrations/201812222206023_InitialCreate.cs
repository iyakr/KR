namespace mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categ_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.categ_name);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        event_Id = c.Int(nullable: false, identity: true),
                        event_name = c.String(),
                        event_price = c.Int(nullable: false),
                        event_info = c.String(),
                        event_pict = c.Byte(nullable: false),
                        event_date = c.DateTime(nullable: false),
                        categ_name = c.String(maxLength: 128),
                        name_place = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.event_Id)
                .ForeignKey("dbo.Categories", t => t.categ_name)
                .ForeignKey("dbo.Places", t => t.name_place)
                .Index(t => t.categ_name)
                .Index(t => t.name_place);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        name_place = c.String(nullable: false, maxLength: 128),
                        addres_place = c.String(),
                        place_info = c.String(),
                        telefon_place = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.name_place);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        pursh_Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.pursh_Id);
            
            CreateTable(
                "dbo.EventPurchase",
                c => new
                    {
                        purchaseId = c.Int(nullable: false),
                        eventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.purchaseId, t.eventId })
                .ForeignKey("dbo.Purchases", t => t.purchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.purchaseId)
                .Index(t => t.eventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventPurchase", "eventId", "dbo.Events");
            DropForeignKey("dbo.EventPurchase", "purchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Events", "name_place", "dbo.Places");
            DropForeignKey("dbo.Events", "categ_name", "dbo.Categories");
            DropIndex("dbo.EventPurchase", new[] { "eventId" });
            DropIndex("dbo.EventPurchase", new[] { "purchaseId" });
            DropIndex("dbo.Events", new[] { "name_place" });
            DropIndex("dbo.Events", new[] { "categ_name" });
            DropTable("dbo.EventPurchase");
            DropTable("dbo.Purchases");
            DropTable("dbo.Places");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
        }
    }
}
