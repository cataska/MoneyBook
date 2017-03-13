using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountBookController : Controller
    {
        private SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

        // GET: AccountBook
        public ActionResult Index()
        {
            var models = db.AccountBook.Select(c => new AccountViewModel()
            {
                Value = c.Amounttt,
                Created = c.Dateee,
                Note = c.Remarkkk,
                Type = c.Categoryyy == 0 ? "支出" : "收入"
            }).ToList();

            return View(models);
        }
    }
}