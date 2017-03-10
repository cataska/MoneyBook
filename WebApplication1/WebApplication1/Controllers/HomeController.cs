using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var models = new List<AccountViewModel>()
            {
                new AccountViewModel() { Type = "支出", Value = 300, Created = new DateTime(2016, 1, 1), Note = "" },
                new AccountViewModel() { Type = "支出", Value = 16000, Created = new DateTime(2016, 1, 2), Note = "" },
                new AccountViewModel() { Type = "支出", Value = 8000, Created = new DateTime(2016, 1, 3), Note = "" }
            };
            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}