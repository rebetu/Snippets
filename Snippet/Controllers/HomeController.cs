using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snippet.DataAccess;
using Snippet.Models;

namespace Snippet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //using (var db = new MainContext())
            //{
            //    var user = new AppUser
            //    {
            //        Email = "email",
            //        CreatedDate = DateTime.Now
            //    };

            //    db.AppUsers.Add(user);
            //}
            

           return View();
        }
    }
}
