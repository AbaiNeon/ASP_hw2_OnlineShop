namespace ASP_hw2_OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBasketmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemBaskets", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemBaskets", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.ItemBaskets", new[] { "Item_Id" });
            DropIndex("dbo.ItemBaskets", new[] { "Basket_Id" });
            CreateTable(
                "dbo.UserItems",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Item_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Item_Id);
            
            DropTable("dbo.Baskets");
            DropTable("dbo.ItemBaskets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemBaskets",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Basket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Basket_Id });
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.UserItems", "User_Id", "dbo.Users");
            DropIndex("dbo.UserItems", new[] { "Item_Id" });
            DropIndex("dbo.UserItems", new[] { "User_Id" });
            DropTable("dbo.UserItems");
            CreateIndex("dbo.ItemBaskets", "Basket_Id");
            CreateIndex("dbo.ItemBaskets", "Item_Id");
            AddForeignKey("dbo.ItemBaskets", "Basket_Id", "dbo.Baskets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemBaskets", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
