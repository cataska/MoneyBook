using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class AccountService : IService<AccountViewModel>
    {
        private SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

        public void Add(AccountViewModel viewModel)
        {
            db.AccountBook.Add(new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int) viewModel.Value,
                Categoryyy = TypeToInt(viewModel.Type),
                Dateee = viewModel.Created,
                Remarkkk = viewModel.Note
            });
        }

        private int TypeToInt(string type)
        {
            return type == "支出" ? 0 : 1;
        }

        public void Delete(AccountViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(AccountViewModel oldViewModel, AccountViewModel newViewModel)
        {
            throw new NotImplementedException();
        }

        public AccountViewModel GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountViewModel> Lookup()
        {
            var query = db.AccountBook.Select(c => new AccountViewModel()
            {
                Value = c.Amounttt,
                Created = c.Dateee,
                Note = c.Remarkkk,
                Type = c.Categoryyy == 0 ? "支出" : "收入"
            });
            return query.Any() == false ? new List<AccountViewModel>() : query.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}