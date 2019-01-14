namespace ASP_hw2_OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemBaskets",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Basket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Basket_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Basket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemBaskets", "Basket_Id", "dbo.Baskets");
            DropForeignKey("dbo.ItemBaskets", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemBaskets", new[] { "Basket_Id" });
            DropIndex("dbo.ItemBaskets", new[] { "Item_Id" });
            DropTable("dbo.ItemBaskets");
            DropTable("dbo.Users");
            DropTable("dbo.Items");
            DropTable("dbo.Baskets");
        }
    }
}
