using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CoffeSite.Models;

namespace CoffeSite.Controllers
{
    public class UserController : Controller
    {
        DataClasses1DataContext DataBase = new DataClasses1DataContext();


        // GET: User
        public ActionResult Pass()
        {
            List<UserLogin> pass = new List<UserLogin>();
            pass = DataBase.UserLogins.ToList();
            return View(pass);
        }
        [HttpPost]
        public ActionResult Pass(UserLogin u)
        {
            var user = DataBase.UserLogins.Where(x => x.Username == u.Username && x.Userpassword == u.Userpassword).Count();
            if (user>0)
            {
                HttpCookie cookie1 = new HttpCookie("Users");
                HttpCookie cookie2 = new HttpCookie("User");
                cookie1.Values.Add("Login", "1");
                cookie1.Values.Add("User", "2");
                cookie2.Values.Add("Admin", "3");
                cookie2.Values.Add("Home", "4");
                Response.Cookies.Add(cookie1);
                Response.Cookies.Add(cookie2);

                return RedirectToAction("../Admin/About");
            }
            else
            {
                return View();
            }
        }
    }
}