using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IService<TViewModel>
        where TViewModel : class
    {
        IEnumerable<TViewModel> Lookup();
        void Add(TViewModel viewModel);
        TViewModel GetSingle(Guid id);
        void Edit(TViewModel oldViewModel, TViewModel newViewModel);
        void Delete(TViewModel viewModel);
        void Save();
    }
}