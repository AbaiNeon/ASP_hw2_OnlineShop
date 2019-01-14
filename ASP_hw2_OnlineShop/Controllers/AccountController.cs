using ASP_hw2_OnlineShop.Areas.admin.Models;
using ASP_hw2_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_hw2_OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private List<Item> BooksInBasket { get; set; } = new List<Item>();
        // GET: Account
        public ActionResult Index()
        {
            using (ShopContext db = new ShopContext())
            {
                return View(db.Users.ToList());
            }
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                using (ShopContext db = new ShopContext())
                {
                    var usr = db.Users.Single(u => u.Login == user.Login && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["Login"] = usr.Login.ToString();

                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login or Password is wrong!");
                    }

                }

                ViewBag.Login = user.Login;
            }
            catch (Exception)
            {

            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Login"] != null)
            {
                using (ShopContext db = new ShopContext())
                {
                    return View(db.Items.ToList());
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Detail(int id)
        {
            using (ShopContext db = new ShopContext())
            {
                var item = db.Items.Single(i => i.Id == id);

                ViewBag.Name = item.Name;
                ViewBag.Price = item.Price;
                return View();
            }
        }

        
        public ActionResult AddToBasket(int id)
        {
            try
            {
                using (ShopContext db = new ShopContext())
                {
                    Item item = db.Items.First(i => i.Id == id);
                    string login = Session["Login"].ToString();
                    User usr = db.Users.First(i => i.Login == login);

                    usr.Items.Add(item);
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

            return RedirectToAction("Basket");
        }

        public ActionResult Basket()
        {
            using (ShopContext db = new ShopContext())
            {
                string login = Session["Login"].ToString();
                BooksInBasket = db.Users.Where(u => u.Login == login).SelectMany(i => i.Items).ToList();
                return View(BooksInBasket);
            }
            
        }

        public ActionResult Buy()
        {
            using (ShopContext db = new ShopContext())
            {
                //здесь должен быть код очистки таблицы UserItems
                

                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}