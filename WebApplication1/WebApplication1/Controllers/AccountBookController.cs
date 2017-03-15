using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AccountBookController : Controller
    {
        private readonly AccountService _service;

        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _service = new AccountService(unitOfWork);
        }
        // GET: AccountBook
        public ActionResult Index()
        {
            return View(_service.Lookup());
        }
    }
}