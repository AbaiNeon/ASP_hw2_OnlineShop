namespace ASP_hw2_OnlineShop
{
    using ASP_hw2_OnlineShop.Areas.admin.Models;
    using ASP_hw2_OnlineShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        
    }


}