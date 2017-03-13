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
        private SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

        public ActionResult Index()
        {
            //var models = new List<AccountViewModel>();
            List<AccountViewModel> models =
                db.AccountBook.Select(c => new AccountViewModel()
                {
                    Value = c.Amounttt,
                    Created = c.Dateee,
                    Note = c.Remarkkk,
                    Type = c.Categoryyy == 0 ? "支出" : "收入"
                }).ToList();

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