using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class AccountService : IService<AccountViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<AccountBook> _accountBookRep;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBookRep = new Repository<AccountBook>(unitOfWork);
        }

        public void Add(AccountViewModel viewModel)
        {
            Add(new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int)viewModel.Value,
                Categoryyy = TypeToInt(viewModel.Type),
                Dateee = viewModel.Created,
                Remarkkk = viewModel.Note
            });
        }

        public void Add(AccountBook accountBook)
        {
            _accountBookRep.Create(accountBook);           
        }

        private static int TypeToInt(string type)
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
            var accountBook = _accountBookRep.GetSingle(c => c.Id == id);
            return new AccountViewModel()
            {
                Value = accountBook.Amounttt,
                Created = accountBook.Dateee,
                Note = accountBook.Remarkkk,
                Type = IntToType(accountBook.Categoryyy)
            };
        }

        private static string IntToType(int n)
        {
            return n == 0 ? "支出" : "收入";
        }

        public IEnumerable<AccountViewModel> Lookup()
        {
            var source = _accountBookRep.LookupAll();
            var result = source.Select(c => new AccountViewModel()
            {
                Value = c.Amounttt,
                Created = c.Dateee,
                Note = c.Remarkkk,
                Type = c.Categoryyy == 0 ? "支出" : "收入"
            }).ToList();
            return result;
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}