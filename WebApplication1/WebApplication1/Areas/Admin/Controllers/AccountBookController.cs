using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class AccountBookController : Controller
    {
        private readonly AccountService _service;
        private const string Admin = "admin@test.com";

        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _service = new AccountService(unitOfWork);
        }

        // GET: AccountBook
        public ActionResult Index()
        {
            if (User.Identity.Name != Admin)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        [Authorize(Users = Admin)]
        [ChildActionOnly]
        public ActionResult List()
        {
            return View("_AccountBookList", _service.Lookup());
        }

        [Authorize(Users = Admin)]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _service.GetSingle(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid id)
        {
            var model = _service.GetSingle(id);
            _service.Delete(model);
            _service.Save();
            return RedirectToAction("Index", "AccountBook", new { area = "Admin" });
        }
    }
}