using ASP_hw2_OnlineShop.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_hw2_OnlineShop.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public ICollection<User> Users { get; set; }
        public Item()
        {
            Users = new List<User>();
        }
    }
}