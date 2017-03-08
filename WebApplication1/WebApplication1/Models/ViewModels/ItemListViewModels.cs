using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ItemListViewModels
    {
        private List<Item> _items;

        public ItemListViewModels()
        {
            this._items = new List<Item>();
        }

        public void Add(Item item)
        {
            this._items.Add(item);
        }

        public List<Item> Items => this._items;
    }
}